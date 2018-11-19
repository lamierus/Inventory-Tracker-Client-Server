using System;
using System.Collections.Generic;
using System.Text;

namespace Loaned_PC_Tracker_Server {

    public class RequestPCPacket : Packet {
        public string SiteName { get; set; }
        public string Type { get; set; }
        public override int PacketLength {
            get { return CreateDataStream().Length; }
        }

        // Default Constructor
        public RequestPCPacket() {
            Identifier = DataIdentifier.Request;
            SiteName = string.Empty;
            Type = string.Empty;
        }

        public RequestPCPacket(string name, string type) {
            Identifier = DataIdentifier.Request;
            SiteName = name;
            Type = type;
        }

        public RequestPCPacket(byte[] dataStream) {
            ParsePacket(dataStream);
        }

        public void ParsePacket(byte[] dataStream) {
            // Read the data identifier from the beginning of the stream (4 bytes)
            Identifier = (DataIdentifier)BitConverter.ToInt32(dataStream, 0);

            // Read the length of the name (4 bytes)
            int nameLength = BitConverter.ToInt32(dataStream, 4);

            // Read the length of the name (4 bytes)
            int typeLength = BitConverter.ToInt32(dataStream, 8);

            // Read the name field
            if (nameLength > 0)
                SiteName = Encoding.UTF8.GetString(dataStream, 12, nameLength);
            else
                SiteName = null;

            // Read the type field
            if (typeLength > 0)
                Type = Encoding.UTF8.GetString(dataStream, 12 + nameLength, typeLength);
            else
                Type = null;
        }

        // Converts the packet into a byte array for sending/receiving 
        public override byte[] CreateDataStream() {
            List<byte> dataStream = new List<byte>();

            // Add the dataIdentifier
            dataStream.AddRange(BitConverter.GetBytes((int)Identifier));

            // Add the name length
            if (SiteName != null)
                dataStream.AddRange(BitConverter.GetBytes(SiteName.Length));
            else
                dataStream.AddRange(BitConverter.GetBytes(0));

            // Add the name length
            if (Type != null)
                dataStream.AddRange(BitConverter.GetBytes(Type.Length));
            else
                dataStream.AddRange(BitConverter.GetBytes(0));

            // Add the name
            if (SiteName != null)
                dataStream.AddRange(Encoding.UTF8.GetBytes(SiteName));

            // Add the name
            if (Type != null)
                dataStream.AddRange(Encoding.UTF8.GetBytes(Type));

            dataStream.AddRange(Encoding.UTF8.GetBytes(";"));

            return dataStream.ToArray();
        }
    }
}

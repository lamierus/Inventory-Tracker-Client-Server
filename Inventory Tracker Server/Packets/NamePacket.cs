using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_Tracker_Server {
    // ----------------
    // Packet Structure
    // ----------------

    // Description   -> |dataIdentifier|name length|    name   |
    // Size in bytes -> |       4      |     4     |name length|

    public class NamePacket : Packet {
        public string Name { get; set; }
        public override int PacketLength {
            get { return CreateDataStream().Length; }
        }

        // Default Constructor
        public NamePacket() {
            Identifier = DataIdentifier.Name;
            Name = string.Empty;
        }

        public NamePacket(string name) {
            Identifier = DataIdentifier.Name;
            Name = name;
        }

        public NamePacket(byte[] dataStream) {
            ParsePacket(dataStream);
        }

        public void ParsePacket(byte[] dataStream) {
            // Read the data identifier from the beginning of the stream (4 bytes)
            Identifier = (DataIdentifier)BitConverter.ToInt32(dataStream, 0);

            // Read the length of the name (4 bytes)
            int nameLength = BitConverter.ToInt32(dataStream, 4);

            // Read the name field
            if (nameLength > 0)
                Name = Encoding.UTF8.GetString(dataStream, 8, nameLength);
            else
                Name = null;
        }

        // Converts the packet into a byte array for sending/receiving 
        public override byte[] CreateDataStream() {
            List<byte> dataStream = new List<byte>();

            // Add the dataIdentifier
            dataStream.AddRange(BitConverter.GetBytes((int)Identifier));

            // Add the name length
            if (Name != null)
                dataStream.AddRange(BitConverter.GetBytes(Name.Length));
            else
                dataStream.AddRange(BitConverter.GetBytes(0));

            // Add the name
            if (Name != null)
                dataStream.AddRange(Encoding.UTF8.GetBytes(Name));

            dataStream.AddRange(Encoding.UTF8.GetBytes(";"));

            return dataStream.ToArray();
        }
    }
}

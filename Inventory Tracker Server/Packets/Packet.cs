using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_Tracker_Server {
    public class Packet {
        public DataIdentifier Identifier { get; set; }
        public virtual int PacketLength {
            get { return CreateDataStream().Length; }
        }

        // Default Constructor
        public Packet() {
            Identifier = DataIdentifier.Null;
        }

        public virtual byte[] CreateDataStream() {
            List<byte> dataStream = new List<byte>();

            // Add the dataIdentifier
            dataStream.AddRange(BitConverter.GetBytes((int)Identifier));

            dataStream.AddRange(Encoding.UTF8.GetBytes(";"));

            return dataStream.ToArray();
        }
    }
}

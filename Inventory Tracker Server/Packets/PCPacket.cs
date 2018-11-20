using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_Tracker_Server {
    // ----------------
    // Packet Structure
    // ----------------

    // Description   -> |dataIdentifier|
    // Size in bytes -> |       4      |

    // Desc. Cont'd  -> |client name length|number length|serial length|brand length|model length|warranty length|username length|user PC serial length|ticket length|checkedout length|
    // Size in bytes -> |         4        |     4       |      4      |     4      |     4      |       4       |       4       |          4          |       4     |        4        |

    // Desc. Cont'd  -> |client name length|...
    // Size in bytes -> |client name length|...

    public class PCPacket : Packet {
        public string Client { get; set; }
        public int Number { get; set; }
        public string Serial { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Warranty { get; set; }
        public string UserName { get; set; }
        public string UserPCSerial { get; set; }
        public string Ticket { get; set; }
        public bool CheckedOut { get; set; }
        public override int PacketLength {
            get { return CreateDataStream().Length; }
        }

        // Default Constructor
        public PCPacket() {
            Identifier = DataIdentifier.Laptop;
            UserName = null;
        }

        public PCPacket(byte[] dataStream) {
            GetPacket(dataStream);
        }

        public void GetPacket(byte[] dataStream) {
            int index = 0;
            // Read the data identifier from the beginning of the stream (4 bytes)
            Identifier = (DataIdentifier)BitConverter.ToInt32(dataStream, index);
            index += 4;
            
            // Read the length of the name (4 bytes)
            int clientLength = BitConverter.ToInt32(dataStream, index);
            index += 4;
            
            // Read the length of the number (4 bytes)
            int numberLength = BitConverter.ToInt32(dataStream, index);
            index += 4;
            
            // Read the length of the serial (4 bytes)
            int serialLength = BitConverter.ToInt32(dataStream, index);
            index += 4;
            
            // Read the length of the name (4 bytes)
            int brandLength = BitConverter.ToInt32(dataStream, index);
            index += 4;
            
            // Read the length of the name (4 bytes)
            int modelLength = BitConverter.ToInt32(dataStream, index);
            index += 4;
            
            // Read the length of the name (4 bytes)
            int warrantyLength = BitConverter.ToInt32(dataStream, index);
            index += 4;
            
            // Read the length of the name (4 bytes)
            int usernameLength = BitConverter.ToInt32(dataStream, index);
            index += 4;
            
            // Read the length of the name (4 bytes)
            int userPCSerialLength = BitConverter.ToInt32(dataStream, index);
            index += 4;
            
            // Read the length of the name (4 bytes)
            int ticketLength = BitConverter.ToInt32(dataStream, index);
            index += 4;
            
            // Read the length of the name (4 bytes)
            int checkedOutLength = BitConverter.ToInt32(dataStream, index);
            index += 4;
            
            // Read the name field
            if (clientLength > 0)
                UserName = Encoding.UTF8.GetString(dataStream, index, clientLength);
            else
                UserName = null;
            index += clientLength;

            // Read the name field
            if (numberLength > 0)
                Number = BitConverter.ToInt32(dataStream, index);
            else
                Number = 0;
            index += numberLength;

            // Read the name field
            if (serialLength > 0)
                Serial = Encoding.UTF8.GetString(dataStream, index, serialLength);
            else
                Serial = null;
            index += serialLength;

            // Read the name field
            if (brandLength > 0)
                Brand = Encoding.UTF8.GetString(dataStream, index, brandLength);
            else
                Brand = null;
            index += brandLength;

            // Read the name field
            if (modelLength > 0)
                Model = Encoding.UTF8.GetString(dataStream, index, modelLength);
            else
                Model = null;
            index += modelLength;

            // Read the name field
            if (warrantyLength > 0)
                Warranty = Encoding.UTF8.GetString(dataStream, index, warrantyLength);
            else
                Warranty = null;
            index += warrantyLength;

            // Read the name field
            if (usernameLength > 0)
                UserName = Encoding.UTF8.GetString(dataStream, index, usernameLength);
            else
                UserName = null;
            index += usernameLength;

            // Read the name field
            if (userPCSerialLength > 0)
                UserPCSerial = Encoding.UTF8.GetString(dataStream, index, userPCSerialLength);
            else
                UserPCSerial = null;
            index += userPCSerialLength;

            // Read the name field
            if (ticketLength > 0)
                Ticket = Encoding.UTF8.GetString(dataStream, index, ticketLength);
            else
                Ticket = null;
            index += ticketLength;

            // Read the name field
            if (checkedOutLength > 0)
                CheckedOut = BitConverter.ToBoolean(dataStream, index);
            else
                CheckedOut = false;
        }

        // Converts the packet into a byte array for sending/receiving 
        public override byte[] CreateDataStream() {
            List<byte> dataStream = new List<byte>();

            // Add the dataIdentifier
            dataStream.AddRange(BitConverter.GetBytes((int)Identifier));

            // Add the name length
            if (Client != null)
                dataStream.AddRange(BitConverter.GetBytes(Client.Length));
            else
                dataStream.AddRange(BitConverter.GetBytes(0));

            // Add the name length
            if (Number != 0)
                dataStream.AddRange(BitConverter.GetBytes(Number));
            else
                dataStream.AddRange(BitConverter.GetBytes(0));

            // Add the name length
            if (Serial != null)
                dataStream.AddRange(BitConverter.GetBytes(Serial.Length));
            else
                dataStream.AddRange(BitConverter.GetBytes(0));

            // Add the name length
            if (Brand != null)
                dataStream.AddRange(BitConverter.GetBytes(Brand.Length));
            else
                dataStream.AddRange(BitConverter.GetBytes(0));

            // Add the name length
            if (Model != null)
                dataStream.AddRange(BitConverter.GetBytes(Model.Length));
            else
                dataStream.AddRange(BitConverter.GetBytes(0));

            // Add the name length
            if (Warranty != null)
                dataStream.AddRange(BitConverter.GetBytes(Warranty.Length));
            else
                dataStream.AddRange(BitConverter.GetBytes(0));

            // Add the name length
            if (UserName != null)
                dataStream.AddRange(BitConverter.GetBytes(UserName.Length));
            else
                dataStream.AddRange(BitConverter.GetBytes(0));

            // Add the name length
            if (UserPCSerial != null)
                dataStream.AddRange(BitConverter.GetBytes(UserPCSerial.Length));
            else
                dataStream.AddRange(BitConverter.GetBytes(0));

            // Add the name length
            if (Ticket != null)
                dataStream.AddRange(BitConverter.GetBytes(Ticket.Length));
            else
                dataStream.AddRange(BitConverter.GetBytes(0));

            // Add the name length
            dataStream.AddRange(BitConverter.GetBytes(CheckedOut));

            // Add the name
            if (Client != null)
                dataStream.AddRange(Encoding.UTF8.GetBytes(Client));

            // Add the name
            if (Number != 0)
                dataStream.AddRange(Encoding.UTF8.GetBytes(UserName));

            // Add the name
            if (Serial != null)
                dataStream.AddRange(Encoding.UTF8.GetBytes(Serial));

            // Add the name
            if (Brand != null)
                dataStream.AddRange(Encoding.UTF8.GetBytes(Brand));

            // Add the name
            if (Model != null)
                dataStream.AddRange(Encoding.UTF8.GetBytes(Model));

            // Add the name
            if (Warranty != null)
                dataStream.AddRange(Encoding.UTF8.GetBytes(Warranty));

            // Add the name
            if (UserName != null)
                dataStream.AddRange(Encoding.UTF8.GetBytes(UserName));

            // Add the name
            if (UserPCSerial != null)
                dataStream.AddRange(Encoding.UTF8.GetBytes(UserPCSerial));

            // Add the name
            if (Ticket != null)
                dataStream.AddRange(Encoding.UTF8.GetBytes(Ticket));

            dataStream.AddRange(BitConverter.GetBytes(CheckedOut));

            dataStream.AddRange(Encoding.UTF8.GetBytes(";"));

            return dataStream.ToArray();
        }
    }
}

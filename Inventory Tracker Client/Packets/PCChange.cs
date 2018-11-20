using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_Tracker_Client {

    public class PCChange : Packet {
        public string Serial { get; set; }
        public string UserName { get; set; }
        public string UserPCSerial { get; set; }
        public string Ticket { get; set; }
        public bool CheckedOut { get; set; }

        public override int PacketLength {
            get { return CreateDataStream().Length; }
        }

        // Default Constructor
        public PCChange() {
            Identifier = DataIdentifier.Update;
        }

        public PCChange(Laptop PC) {
            Identifier = DataIdentifier.Update;
            Serial = PC.Serial;
            UserName = PC.Username;
            UserPCSerial = PC.UserPCSerial;
            Ticket = PC.TicketNumber;
            CheckedOut = PC.CheckedOut;
        }

        public PCChange(byte[] dataStream) {
            GetPacket(dataStream);
        }

        public void GetPacket(byte[] dataStream) {
            int index = 0;
            // Read the data identifier from the beginning of the stream (4 bytes)
            Identifier = (DataIdentifier)BitConverter.ToInt32(dataStream, index);
            index += 4;

            // Read the length of the serial (4 bytes)
            int serialLength = BitConverter.ToInt32(dataStream, index);
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
            
            // Read the name field
            if (serialLength > 0)
                Serial = Encoding.UTF8.GetString(dataStream, index, serialLength);
            else
                Serial = null;
            index += serialLength;

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
            CheckedOut = BitConverter.ToBoolean(dataStream, index);
        }


        // Converts the packet into a byte array for sending/receiving 
        public override byte[] CreateDataStream() {
            //byte[] seperator = BitConverter.GetBytes(',');
            List<byte> dataStream = new List<byte>();

            // Add the dataIdentifier
            dataStream.AddRange(BitConverter.GetBytes((int)Identifier));
            //dataStream.AddRange(seperator);

            // Add the serial length
            if (Serial != null)
                dataStream.AddRange(BitConverter.GetBytes(Serial.Length));
            else
                dataStream.AddRange(BitConverter.GetBytes(0));
            //dataStream.AddRange(seperator);

            // Add the username length
            if (UserName != null)
                dataStream.AddRange(BitConverter.GetBytes(UserName.Length));
            else
                dataStream.AddRange(BitConverter.GetBytes(0));
            //dataStream.AddRange(seperator);

            // Add the user's PC serial# length
            if (UserPCSerial != null)
                dataStream.AddRange(BitConverter.GetBytes(UserPCSerial.Length));
            else
                dataStream.AddRange(BitConverter.GetBytes(0));
            //dataStream.AddRange(seperator);

            // Add the ticket# length
            if (Ticket != null)
                dataStream.AddRange(BitConverter.GetBytes(Ticket.Length));
            else
                dataStream.AddRange(BitConverter.GetBytes(0));
            //dataStream.AddRange(seperator);

            // Add the serial
            if (Serial != null)
                dataStream.AddRange(Encoding.UTF8.GetBytes(Serial));
            //dataStream.AddRange(seperator);

            // Add the username
            if (UserName != null)
                dataStream.AddRange(Encoding.UTF8.GetBytes(UserName));
            //dataStream.AddRange(seperator);

            // Add the user's PC serial#
            if (UserPCSerial != null)
                dataStream.AddRange(Encoding.UTF8.GetBytes(UserPCSerial));
            //dataStream.AddRange(seperator);

            // Add the ticket#
            if (Ticket != null)
                dataStream.AddRange(Encoding.UTF8.GetBytes(Ticket));
            //dataStream.AddRange(seperator);

            dataStream.AddRange(BitConverter.GetBytes(CheckedOut));
            //dataStream.AddRange(seperator);

            dataStream.AddRange(Encoding.UTF8.GetBytes(";"));

            return dataStream.ToArray();
        }
    }
}

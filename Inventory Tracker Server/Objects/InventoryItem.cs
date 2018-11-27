using System;
using System.Text;
using System.Collections.Generic;

namespace Inventory_Tracker_Server {
    public class InventoryItem : IEquatable<InventoryItem> {

        public string Brand { get; set; }
        public string Description { get; set; }
        public string PartNumber { get; set; }
        public string OldPartNumber { get; set; }
        public int CurrentCount { get; set; }
        public int NumNeeded { get; set; }
        public int NumOrdered { get; set; }
        public double Price { get; set; }
        public int NumAccountedFor {
            get { return (CurrentCount + NumNeeded + NumOrdered); }
        }

        readonly char[] Seperator = new char[] { ',' };
        readonly char[] TrimChar = new char[] { '\0' };

        public InventoryItem() {

        }

        public InventoryItem(string brand, string description, string partNum, string oldPartNum, int inStock, int toOrder,
                                int ordered, Double price) {
            Brand = brand;
            Description = description;
            PartNumber = partNum;
            OldPartNumber = oldPartNum;
            CurrentCount = inStock;
            NumNeeded = toOrder;
            NumOrdered = ordered;
            Price = price;
        }


        public InventoryItem(byte[] dataStream) {
            Deserialize(dataStream);
        }

        public byte[] Serialize() {
            byte[] seperator = BitConverter.GetBytes(',');
            List<byte> serializedItem = new List<byte>();

            // Add the Brand
            if (Brand != null)
                serializedItem.AddRange(Encoding.UTF8.GetBytes(Brand));
            serializedItem.AddRange(seperator);

            // Add the Description
            if (Description != null)
                serializedItem.AddRange(Encoding.UTF8.GetBytes(Description));
            serializedItem.AddRange(seperator);

            // Add the Part Number
            if (PartNumber != null)
                serializedItem.AddRange(Encoding.UTF8.GetBytes(PartNumber));
            serializedItem.AddRange(seperator);

            // Add the Old Part Number
            if (OldPartNumber != null)
                serializedItem.AddRange(Encoding.UTF8.GetBytes(OldPartNumber));
            serializedItem.AddRange(seperator);

            // Add the Current Count of Items
            serializedItem.AddRange(Encoding.UTF8.GetBytes(CurrentCount.ToString()));
            serializedItem.AddRange(seperator);

            // Add the Number of Needed Items
            serializedItem.AddRange(Encoding.UTF8.GetBytes(NumNeeded.ToString()));
            serializedItem.AddRange(seperator);

            // Add the Number of Ordered Items
            serializedItem.AddRange(Encoding.UTF8.GetBytes(NumOrdered.ToString()));
            serializedItem.AddRange(seperator);

            // Add the Price
            serializedItem.AddRange(Encoding.UTF8.GetBytes(Price.ToString()));
            serializedItem.AddRange(seperator);

            // Add the seperator to signify the end of the serialized item.
            serializedItem.AddRange(BitConverter.GetBytes(';'));

            return serializedItem.ToArray();
        }

        private void Deserialize(byte[] serializedItem) {
            string dataString = Encoding.UTF8.GetString(serializedItem);
            string[] splitString = dataString.Split(Seperator, StringSplitOptions.RemoveEmptyEntries);

            Brand = splitString[0].Trim(TrimChar);
            Description = splitString[1].Trim(TrimChar);
            PartNumber = splitString[2].Trim(TrimChar);
            OldPartNumber = splitString[3].Trim(TrimChar);

            int parsedNum;
            if (int.TryParse(splitString[4].Trim(TrimChar), out parsedNum)) {
                CurrentCount = parsedNum;
            }
            if (int.TryParse(splitString[5].Trim(TrimChar), out parsedNum)) {
                NumNeeded = parsedNum;
            }
            if (int.TryParse(splitString[6].Trim(TrimChar), out parsedNum)) {
                NumOrdered = parsedNum;
            }

            double parsedDub;
            if (double.TryParse(splitString[7].Trim(TrimChar), out parsedDub)) {
                Price = parsedDub;
            }
        }

        public InventoryItem Deserialize(string serializedItem) {
            InventoryItem deserializedItem = new InventoryItem();

            string[] splitString = serializedItem.Split(Seperator, StringSplitOptions.RemoveEmptyEntries);

            deserializedItem.Brand = splitString[0].Trim(TrimChar);
            deserializedItem.Description = splitString[1].Trim(TrimChar);
            deserializedItem.PartNumber = splitString[2].Trim(TrimChar);
            deserializedItem.OldPartNumber = splitString[3].Trim(TrimChar);

            int parsedNum;
            if (int.TryParse(splitString[4].Trim(TrimChar), out parsedNum)) {
                deserializedItem.CurrentCount = parsedNum;
            }
            if (int.TryParse(splitString[5].Trim(TrimChar), out parsedNum)) {
                deserializedItem.NumNeeded = parsedNum;
            }
            if (int.TryParse(splitString[6].Trim(TrimChar), out parsedNum)) {
                deserializedItem.NumOrdered = parsedNum;
            }

            double parsedDub;
            if (double.TryParse(splitString[7].Trim(TrimChar), out parsedDub)) {
                deserializedItem.Price = parsedDub;
            }


            return deserializedItem;
        }
        /*
        public void MergeChanges(PCChange changes) {
            Serial = changes.Serial;
            Username = changes.UserName;
            UserPCSerial = changes.UserPCSerial;
            TicketNumber = changes.Ticket;
            CheckedOut = changes.CheckedOut;
        }*/

        // the logic required to be able to compare CSATs to each other
        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            InventoryItem objAsPC = obj as InventoryItem;
            if (objAsPC == null) {
                return false;
            } else {
                return Equals(objAsPC);
            }
        }

        public bool Equals(InventoryItem other) {
            if (other == null || other.PartNumber == null) {
                return false;
            }
            return (PartNumber.Equals(other.PartNumber));
        }

        public override int GetHashCode() {
            return PartNumber.GetHashCode();
        }

        public static bool operator ==(InventoryItem lhs, InventoryItem rhs) {
            if (ReferenceEquals(lhs, null)) {
                return ReferenceEquals(rhs, null);
            }
            return lhs.Equals(rhs);
        }

        public static bool operator !=(InventoryItem lhs, InventoryItem rhs) {
            if (ReferenceEquals(lhs, null)) {
                return ReferenceEquals(rhs, null);
            }
            return !(lhs.Equals(rhs));
        }
    }
}
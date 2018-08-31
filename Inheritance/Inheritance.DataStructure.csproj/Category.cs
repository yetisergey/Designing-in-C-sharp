using System;
using System.Text;

namespace Inheritance.DataStructure
{
    public class Category : IComparable
    {
        private MessageType type;
        private MessageTopic topic;
        private string name;

        public Category(string name, MessageType type, MessageTopic topic)
        {
            this.name = name;
            this.type = type;
            this.topic = topic;
        }

        public int CompareTo(object obj)
        {
            if (obj == null || GetType() != obj.GetType() || string.IsNullOrEmpty(name))
                return 1;

            var objCategory = (Category)obj;

            if (name.CompareTo(objCategory.name) < 0) return -1;
            else if (name.CompareTo(objCategory.name) > 0) return 1;

            if (type < objCategory.type) return -1;
            else if (type > objCategory.type) return 1;

            if (topic < objCategory.topic) return -1;
            else if (topic > objCategory.topic) return 1;

            return 0;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType() || string.IsNullOrEmpty(((Category)obj).name))
                return false;

            var objCategory = (Category)obj;

            return type == objCategory.type &&
                name == objCategory.name &&
                topic == objCategory.topic;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            return name + "." + type + "." + topic;
        }

        public static bool operator <(Category left, Category right)
        {
            if (left == null || right == null)
                return false;
            return left.CompareTo(right) < 0;
        }

        public static bool operator >(Category left, Category right)
        {
            if (left == null || right == null)
                return false;
            return left.CompareTo(right) > 0;
        }

        public static bool operator <=(Category left, Category right)
        {
            if (left == null || right == null)
                return false;
            return left.CompareTo(right) < 0 || left.Equals(right);
        }

        public static bool operator >=(Category left, Category right)
        {
            if (left == null || right == null)
                return false;
            return (left.CompareTo(right) > 0 || left.Equals(right));
        }
    }
}
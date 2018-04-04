using System;
using System.Collections.Generic;

namespace HashMaps
{
    public class HashMap<TKey, TVal>
    {
        LinkedList<KeyValuePair<TKey, TVal>>[] data;
        public HashMap(int length = 10)
        {
            data = new LinkedList<KeyValuePair<TKey, TVal>>[length];
        }

        public TVal this[TKey key]
        {
            get
            {
				int hash = key.GetHashCode();
                var ll = data[Math.Abs(hash % data.Length)];
                if(ll == null){
                    throw new Exception("Could not find item");
                }
                foreach(var n in ll){
                    if(n.Key.Equals(key)){
                        return n.Value;
                    }
                }
                throw new Exception("Could not find item");
            }
            set
            {
                int hash = key.GetHashCode();
                var ll = data[Math.Abs(hash % data.Length)];
                if(ll == null){
                    ll = new LinkedList<KeyValuePair<TKey, TVal>>();
                }
                ll.AddFirst(new LinkedListNode<KeyValuePair<TKey, TVal>>(new KeyValuePair<TKey, TVal>(key, value)));
                data[Math.Abs(hash % data.Length)] = ll;
            }
        }

        public HashMap<TKey, TVal> Rehash(int newCount){
            var newData = new HashMap<TKey, TVal>(newCount);
            foreach(var ll in data){
                if (ll == null) continue;
                foreach(var n in ll){
                    newData[n.Key] = n.Value;
                }
            }
            return newData;
        }

        public bool HasValue(TKey key){
			int hash = key.GetHashCode();
			var ll = data[Math.Abs(hash % data.Length)];
			if (ll == null)
			{
                return false;
			}
			foreach (var n in ll)
			{
				if (n.Key.Equals(key))
				{
                    return true;
				}
			}
            return false;
        }
    }
}

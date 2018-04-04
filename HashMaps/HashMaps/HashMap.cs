using System;
using System.Collections.Generic;

namespace HashMaps
{
    public class HashMap<TKey, TVal>
    {
        LinkedList<KeyValuePair<TKey, TVal>>[] data;
        public int Count { get; private set; }

        public HashMap(int length = 10)
        {
            if(length <= 0)
            {
                throw new ArgumentException("length must be greater than 0");
            }

            data = new LinkedList<KeyValuePair<TKey, TVal>>[length];
            Count = 0;
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
                ref var ll = ref data[Math.Abs(hash % data.Length)];
                if(ll == null){
                    Insert(key, value);
                    return;
                }
                    
	            var n = ll.First;
                while (n != null)
	            {
	                if(n.Value.Key.Equals(key)){
                        n.Value = new KeyValuePair<TKey, TVal>(key, value);
                        return;
	                }
	                n = n.Next;
	            }

            }
        }

        public void Rehash(int newCount){
            var oldData = data;
            data = new LinkedList<KeyValuePair<TKey, TVal>>[newCount];
            foreach(var list in oldData){
                if (list == null) continue;
                foreach(var pair in list){
                    Insert(pair.Key, pair.Value);
                }
            }
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

        public void Insert(TKey key, TVal value)
        {
			int hash = key.GetHashCode();
			ref var ll = ref data[Math.Abs(hash % data.Length)];

			if (ll == null)
			{
				ll = new LinkedList<KeyValuePair<TKey, TVal>>();
			}
			Count++;
			ll.AddFirst(new KeyValuePair<TKey, TVal>(key, value));

			if (Count == data.Length)
			{
				Rehash(data.Length * 2);
			}
        }

		public void Remove(TKey key)
		{
			int hash = key.GetHashCode();
			var ll = data[Math.Abs(hash % data.Length)];
			if (ll == null)
			{
                throw new Exception("Key does not exist");
			}
			foreach (var n in ll)
			{
				if (n.Key.Equals(key))
				{
                    ll.Remove(n);
                    data[Math.Abs(hash % data.Length)] = ll;
                    Count--;
                    return;
				}
			}

			throw new Exception("Key does not exist");
		}
    }
}

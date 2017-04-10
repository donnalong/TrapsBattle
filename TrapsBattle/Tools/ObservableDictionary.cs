using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TrapsBattle.Tools
{
    public class ObservableDictionary<TKey, TValue> : IDictionary<TKey, TValue>, INotifyCollectionChanged, INotifyPropertyChanged
    {
        #region IDictionary
        public TValue this[TKey key]
        {
            get { return Dictionary[key]; }
            set
            {
                TValue existingValue;

                if(!Dictionary.TryGetValue(key, out existingValue))
                {
                    Dictionary.Add(key, value);
                }
                else
                {
                    Dictionary[key] = value;

                    OnCollectionChanged(newValue: value, oldValue: existingValue);
                }
            }
        }

        public int Count
        {
            get { return Dictionary.Count; }
        }

        public bool IsReadOnly
        {
            get { return Dictionary.IsReadOnly; }
        }

        public ICollection<TKey> Keys
        {
            get { return Dictionary.Keys; }
        }

        public ICollection<TValue> Values
        {
            get { return Dictionary.Values; }
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Dictionary.Add(item);

            OnCollectionChanged(NotifyCollectionChangedAction.Add, item);
        }

        public void Add(TKey key, TValue value)
        {
            Dictionary.Add(key, value);

            OnCollectionChanged(NotifyCollectionChangedAction.Add, new KeyValuePair<TKey, TValue>(key, value));
        }

        public void Clear()
        {
            Dictionary.Clear();

            OnCollectionChanged();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return Dictionary.Contains(item);
        }

        public bool ContainsKey(TKey key)
        {
            return Dictionary.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            Dictionary.CopyTo(array, arrayIndex);

            OnCollectionChanged(array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return Dictionary.GetEnumerator();
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            bool success = Dictionary.Remove(item);

            if(success)
            {
                OnCollectionChanged(NotifyCollectionChangedAction.Remove, item);
            }

            return success;
        }

        public bool Remove(TKey key)
        {
            bool success;
            TValue value;

            if(success = Dictionary.TryGetValue(key, out value))
            {
                Dictionary.Remove(key);

                OnCollectionChanged(NotifyCollectionChangedAction.Remove, new KeyValuePair<TKey, TValue>(key, value));
            }

            return success;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return Dictionary.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Dictionary.GetEnumerator();
        }
        #endregion

        #region INotifyCollectionChanged
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        private void OnCollectionChanged()
        {
            NotifyCollectionChangedEventArgs args = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset);

            CollectionChanged?.Invoke(this, args);

            UpdateAllProperties();
        }

        private void OnCollectionChanged(NotifyCollectionChangedAction action, object changedItem)
        {
            NotifyCollectionChangedEventArgs args = new NotifyCollectionChangedEventArgs(action, changedItem);

            CollectionChanged?.Invoke(this, args);

            UpdateAllProperties();
        }

        private void OnCollectionChanged(object newValue, object oldValue)
        {
            NotifyCollectionChangedEventArgs args = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, newValue, oldValue);

            CollectionChanged?.Invoke(this, args);

            UpdateAllProperties();
        }

        private void OnCollectionChanged(IList list, int startIndex)
        {
            NotifyCollectionChangedEventArgs args = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Move, list, startIndex);

            CollectionChanged?.Invoke(this, args);

            UpdateAllProperties();
        }
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void UpdateAllProperties()
        {
            OnPropertyChanged("Count");
            OnPropertyChanged("Keys");
            OnPropertyChanged("Values");
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private IDictionary<TKey, TValue> dictionary;
        protected IDictionary<TKey, TValue> Dictionary
        {
            get { return dictionary; }
        }

        public ObservableDictionary()
        {
            dictionary = new Dictionary<TKey, TValue>();
        }
    }
}

namespace Generics.Tables
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    class Table<TKey,TRow , TColumn> : IEnumerable 
        where TKey: IComparable 
        where TRow: IComparable 
        where TColumn : IComparable
    {
        public List<TColumn> Columns { get; set; }
        public List<TRow> Rows { get; set; }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public Open<TKey, TColumn, TRow> Open { get; set; }
        public Existed<TKey, TColumn, TRow> Existed { get; set; }

        public void AddColumn(TColumn v)
        {
            Columns.Add(v);
        }

        public void AddRow(TKey r)
        {
            Rows.Add(r);
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

    }

    public class Open<TKey,TRow , TColumn>
    {
        public Open<TKey, TRow, TColumn> this[TKey i, TColumn j]
        {
            get {
                throw new NotImplementedException();

            }
            set
            {
                
            }
        }
    }

    public class Existed<TKey, TRow, TColumn>
    {
        public Existed<TKey, TRow, TColumn> this[TKey i, TColumn j]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
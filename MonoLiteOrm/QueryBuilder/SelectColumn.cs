using System;

namespace Mono.Mlo
{
	public class SelectColumn
	{
		
		public virtual string TableName {get;set;}
		public virtual string ColumnName {get;set;}
		public virtual string Alias {get;set;}
		
		public SelectColumn ()
		{
		}
		
		public override string ToString ()
		{
			return (TableName == null ? "" : TableName + ".") + ColumnName + (Alias == null ? "" : " " + Alias);
		}
	}
}


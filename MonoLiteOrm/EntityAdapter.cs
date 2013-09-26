using System;
using System.Data;
using System.Text;
using System.Collections.Generic;

namespace Mono.Mlo
{
	/// <summary>
	/// Converts a data set to entities and creates SqlCommands to retrieve required data.
	/// </summary>
	public class EntityAdapter
	{
		
		public EntityAdapter ()
		{
		}
		
		public List<T> toEntities<T>(DataSet dataSet, ClassMapping mapping) where T : new () {
			return null;	
		}
		
		public T toEntity<T>(DataSet dataSet, ClassMapping mapping) where T : new () {
			if (dataSet[mapping.CorrespondingTable.Name].RowCount > 0) {
				return mapEntityProperties<T>(dataSet[mapping.CorrespondingTable.Name].Rows[0], mapping);
			} else {
				return default(T);	
			}
		}
					
		private T mapEntityProperties<T>(DataRow row, ClassMapping mapping) where T : new () {
			T instance = Activator.CreateInstance<T>();
			foreach (FieldMapping fieldMap in mapping.PropertyMappings) {
				fieldMap.Field.Field.SetValue(instance, row[fieldMap.Column.Name]);
			}
			return instance;
		}
		
	}
}


using UnityEngine;
using VRC.SDK3.Data;

namespace Vincil.VUSharp.Extensions
{
    public static class UdonDataExtensions
    {
        /// <summary>
        /// Adds the elements of the specified <see cref="DataList"/> to the <see cref="DataList"/> associated with the
        /// given key in the <see cref="DataDictionary"/>.
        /// </summary>
        /// <remarks>If the specified key does not exist in the <paramref name="dataDictionary"/>, a new
        /// <see cref="DataList"/> is created, added to the dictionary under the given key, and the elements of
        /// <paramref name="dataList"/> are added to it.  If the key exists but is not a <see cref="DataList"/> it will be overwritten.</remarks>
        /// <param name="dataDictionary">The <see cref="DataDictionary"/> to which the data will be added.</param>
        /// <param name="key">The key used to locate the target <see cref="DataList"/> in the dictionary.</param>
        /// <param name="dataList">The <see cref="DataList"/> containing the elements to add.</param>
        public static void AddDataListToContainedDataList(this DataDictionary dataDictionary, DataToken key, DataList dataList)
        {
            if(dataDictionary == null)
            {
                Debug.LogError("[UdonDataExtensions] Base DataDictionary is not initialized!");
            }
            DataList dataListToAddTo;
            if (dataDictionary.TryGetValue(key, TokenType.DataList, out DataToken dataToken))
            {
                dataListToAddTo = dataToken.DataList;
            }
            else
            {
                dataListToAddTo = new DataList();
                dataDictionary[key] = new DataToken(dataListToAddTo);
            }
            dataListToAddTo.AddRange(dataList);
        }

        /// <summary>
        /// Adds a <see cref="DataToken"/> to a <see cref="DataList"/> contained within the specified <see
        /// cref="DataDictionary"/>.
        /// </summary>
        /// <remarks>If the specified key does not exist in the <paramref name="dataDictionary"/>, a new
        /// <see cref="DataList"/> is created, added to the dictionary under the given key, and the <paramref name="DataToken"/>
        /// will be added to it.  If the key exists but is not a <see cref="DataList"/> it will be overwritten.</remarks>
        /// <param name="dataDictionary">The <see cref="DataDictionary"/> to which the <paramref name="dataToken"/> will be added.</param>
        /// <param name="key">The key identifying the <see cref="DataList"/> within the <paramref name="dataDictionary"/>. If the key does
        /// not exist, a new <see cref="DataList"/> is created and added to the dictionary.</param>
        /// <param name="dataToken">The <see cref="DataToken"/> to add to the <see cref="DataList"/>.</param>
        public static void AddDataTokenToContainedDataList(this DataDictionary dataDictionary, DataToken key, DataToken dataToken)
        {
            if (dataDictionary == null)
            {
                Debug.LogError("[UdonDataExtensions] Base DataDictionary is not initialized!");
            }
            DataList dataListToAddTo;
            if (dataDictionary.TryGetValue(key, TokenType.DataList, out DataToken outToken))
            {
                dataListToAddTo = outToken.DataList;
            }
            else
            {
                dataListToAddTo = new DataList();
                dataDictionary[key] = new DataToken(dataListToAddTo);
            }
            dataListToAddTo.Add(dataToken);
        }

        /// <summary>
        /// Adds a data token to a nested <see cref="DataDictionary"/> within the specified parent <see
        /// cref="DataDictionary"/>.
        /// </summary>
        /// <remarks>If the specified <paramref name="key"/> does not exist in the parent <paramref
        /// name="dataDictionary"/>, a new nested <see cref="DataDictionary"/> is created and associated with the key.
        /// The <paramref name="dataToken"/> is then added to the nested dictionary using the specified <paramref
        /// name="subKey"/>.  If the key exists but is not a <see cref="DataDictionary"/> it will be overwritten.</remarks>
        /// <param name="dataDictionary">The parent <see cref="DataDictionary"/> to which the data token will be added.</param>
        /// <param name="key">The key used to locate or create the nested <see cref="DataDictionary"/> within the parent dictionary.</param>
        /// <param name="subKey">The key used to store the data token in the nested <see cref="DataDictionary"/>.</param>
        /// <param name="dataToken">The data token to add to the nested <see cref="DataDictionary"/>.</param>
        public static void AddDataTokenToContainedDataDictionary(this DataDictionary dataDictionary, DataToken key, DataToken subKey, DataToken dataToken)
        {
            if (dataDictionary == null)
            {
                Debug.LogError("[UdonDataExtensions] Base DataDictionary is not initialized!");
            }
            DataDictionary dataDictionaryToAddTo;
            if (dataDictionary.TryGetValue(key, TokenType.DataDictionary, out DataToken outToken))
            {
                dataDictionaryToAddTo = outToken.DataDictionary;
            }
            else
            {
                dataDictionaryToAddTo = new DataDictionary();
                dataDictionary[key] = new DataToken(dataDictionaryToAddTo);
            }
            dataDictionaryToAddTo.SetValue(subKey, dataToken);
        }
    }
}

using DataModel.EntityModel;
using DataModel.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.UnityOfWork
{
    public interface IUnityOfWork
    {
        #region Properties
        GenericRepository<Hotel> HotelRepository { get; }
       
        #endregion

        #region Public methods
        /// <summary>
        /// Save method.
        /// </summary>
        void Save();
        #endregion
    }
}

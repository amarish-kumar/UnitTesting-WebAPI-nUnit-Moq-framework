using DataModel.EntityModel;
using DataModel.GenericRepository;
using DataModel.UnityOfWork;
using Moq;
using NUnit.Framework;
using Service.Repository;
using Service.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Text.TestHelper;
using System.Linq.Expressions;

namespace Service.Text
{
    /// <summary>
    /// Hotel Service Test
    /// </summary>
    public class HotelServiceTest
    {
        #region Variables

        private IHotelRepository _hotelService;
        private IUnityOfWork _unityOfWork;
        private List<Hotel> _hotels;
        private GenericRepository<Hotel> _hotelepository;
        private BookingTekEntities _dbEntities;
        #endregion

        #region Test fixture setup

        /// <summary>
        /// Initial setup for tests
        /// </summary>
        [TestFixtureSetUp]
        public void Setup()
        {
            _hotels = SetUpProducts();
        }

        #endregion

        #region Setup

        /// <summary>
        /// Re-initializes test.
        /// </summary>
        [SetUp]
        public void ReInitializeTest()
        {
            _hotels = SetUpProducts();
            _dbEntities = new Mock<BookingTekEntities>().Object;
            _hotelepository = SetUpProductRepository();
            var unitOfWork = new Mock<IUnityOfWork>();
            unitOfWork.SetupGet(s => s.HotelRepository).Returns(_hotelepository);
            _unityOfWork = unitOfWork.Object;
            _hotelService = new HotelRepository(_unityOfWork);

        }

        #endregion

        #region Private member methods

        /// <summary>
        /// Setup dummy repository
        /// </summary>
        /// <returns></returns>
        private GenericRepository<Hotel> SetUpProductRepository()
        {
            // Initialise repository
            var mockRepo = new Mock<GenericRepository<Hotel>>(MockBehavior.Default, _dbEntities);

            // Setup mocking behavior
          //  mockRepo.Setup(p => p.GetMany(It.IsInRange<List<Hotel>>())).Returns(_hotels);

            mockRepo.Setup(x => x.GetMany(It.IsIn<Func<Hotel, bool>>())).Returns(_hotels);

            // Return mock implementation object
            return mockRepo.Object;
        }

        /// <summary>
        /// Setup dummy products data
        /// </summary>
        /// <returns></returns>
        private static List<Hotel> SetUpProducts()
        {
            
            var hotels = DataInitializer.GetAllHotels();
          
            return hotels;

        }

        #endregion

        #region Unit Tests

        /// <summary>
        /// Service should return all the hotels
        /// </summary>
        [Test]
        public void GetAllHotelsTest()
        {
            var hotels = _hotelService.GetHotels("Ibis");
            if (hotels != null)
            {
                var hotelList =
                    hotels.Select(
                        hoteldto =>
                        new Hotel {  Id = hoteldto.Id, Hotel_Name = hoteldto.Hotel_Name }).
                        ToList();
                var comparer = new HotelComparer();
                CollectionAssert.AreEqual(
                    hotelList.OrderBy(hotel => hotel, comparer),
                    _hotels.OrderBy(hotel => hotel, comparer), comparer);
            }
        }
        #endregion

    }
}

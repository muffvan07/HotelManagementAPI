using AutoMapper;
using HotelManagement.Entities.BusinessEntities;
using HotelManagement.Entities.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DL.Mapping
{
    class ModelMapping
    {
        public static IMapper MappingConfig()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<tbl_Hotel, HotelLocationVM>()
                .ForMember(x => x.Location,
                    map => map.MapFrom(p => p.Address + " " + p.City + " " + p.Pincode));
                cfg.CreateMap<tbl_Room, RoomVM>()
                .ForMember(x => x.City,
                    map => map.MapFrom(p => p.tbl_Hotel.City))
                .ForMember(x => x.HotelName,
                    map => map.MapFrom(p => p.tbl_Hotel.HotelName))
                .ForMember(x => x.Pincode,
                    map => map.MapFrom(p => p.tbl_Hotel.Pincode));
                cfg.CreateMap<BookingVM, tbl_Bookings>();
                cfg.CreateMap<HotelRoomVM, tbl_Hotel>();
                cfg.CreateMap<Room, tbl_Room>();
            });
            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}

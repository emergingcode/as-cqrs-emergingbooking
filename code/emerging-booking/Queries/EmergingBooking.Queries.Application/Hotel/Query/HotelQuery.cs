﻿using System;

using EmergingBooking.Infrastructure.Cqrs.Queries;

namespace EmergingBooking.Queries.Application.Hotel.Query
{
    public class HotelQuery : IQuery
    {
        public Guid Code { get; }

        public HotelQuery()
        {
        }

        public HotelQuery(Guid code)
        {
            Code = code;
        }
    }
}
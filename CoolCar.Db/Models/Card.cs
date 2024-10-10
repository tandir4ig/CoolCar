﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCar.Db.Models
{
    public class Card
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public List<CardItem> Cars { get; set; }
        public User User { get; set; }
    }
}

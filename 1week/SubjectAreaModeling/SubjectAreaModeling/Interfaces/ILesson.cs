﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.Models;

namespace TrainingCenter.Interfaces
{
    public interface ILesson
    {
        public void Create(Course course);
    }
}

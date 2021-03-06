﻿using finalPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace finalPro.Repositories
{
    public interface IUser<T>
    {
        List<T> getAll();
        List<User> getAllFilter(int id);
        T getByID(params object[] id);
        T Add(T t);
        bool Update(T t);
        bool Delete(int id);
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDD.Repository.MongoDB
{
    public interface IMongoDBContext : IRepositoryContext
    {
        /// <summary>
        /// Gets a <see cref="IMongoDBRepositoryContextSettings"/> instance which contains the settings
        /// information used by current context.
        /// </summary>
        //IMongoDBRepositoryContextSettings Settings { get; }
    }
}

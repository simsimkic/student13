// File:    IArticleRepository.cs
// Created: 23. maj 2020 14:06:57
// Purpose: Definition of Interface IArticleRepository

using System;
using System.Collections.Generic;
using SIMS.Model.UserModel;

namespace SIMS.Repository.Abstract.MiscAbstractRepository
{
    public interface IArticleRepository : IRepository<Article, long>
    {
        IEnumerable<Article> GetArticleByAuthor(Employee author);

    }
}
﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICommentService
    {
        IDataResult<List<Comment>> GetAll();
        IDataResult<List<Comment>> GetAllById(int id);
        IDataResult<Comment> GetById(int commentId);
        IResult Insert(Comment comment);
        IResult Delete(Comment comment);
        IResult Update(Comment comment);
    }
}

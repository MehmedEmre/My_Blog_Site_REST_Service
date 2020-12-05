using My_Blog_Site.Buisness.Abstract;
using My_Blog_Site.DataAccess.Abstract;
using My_Blog_Site.Entities.Entities;
using My_Blog_Site.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace My_Blog_Site.Buisness.Concrete
{
    public class CommentManager:ManagerBase<Comment>,ICommentService
    {
        private readonly ICommentRepository _ICommentRepository;

        public CommentManager(ICommentRepository ICommentRepository):base(ICommentRepository)
        {
            _ICommentRepository = ICommentRepository;
        }
    }
}

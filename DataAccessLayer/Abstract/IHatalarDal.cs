using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Abstract
{
    public interface IHatalarDal
    {
        List<Hatalar> ListAllHatalar();
        void AddHatalar(Hatalar hatalar);
        void DeleteHatalar(Hatalar hatalar);
        void UpdateHatalar(Hatalar hatalar);
        Hatalar GetById(int id);
    }
}

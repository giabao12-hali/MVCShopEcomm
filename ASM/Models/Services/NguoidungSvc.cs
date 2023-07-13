using ASM.Helpers;
using ASM.Models.ViewModels;
using static ASM.Constant.SessionKey;

namespace ASM.Models.Services
{
    public interface INguoiDungSvc
    {
        List<Nguoidung> GetNguoiDungAll();
        Nguoidung GetNguoidung(int id);
        int AddNguoiDung(Nguoidung nguoidung);
        int EditNguoiDung(int id, Nguoidung nguoidung);
        public Nguoidung Login(ViewLogin viewLogin);

    }
    public class NguoidungSvc : INguoiDungSvc
    {
        protected DataContext _context;
        protected IMahoaHelpers _mahoaHelpers;

        public NguoidungSvc(DataContext context, IMahoaHelpers mahoaHelpers)
        {
            _context = context;
            _mahoaHelpers = mahoaHelpers;
        }

        public int AddNguoiDung(Nguoidung nguoidung)
        {
            int ret = 0;
            try
            {
                nguoidung.Password = _mahoaHelpers.Mahoa(nguoidung.Password);
                _context.Add(nguoidung);
                _context.SaveChanges();
                ret = nguoidung.NguoiDungId;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }

        public int EditNguoiDung(int id, Nguoidung nguoidung)
        {
            int ret = 0;
            try
            {
                Nguoidung _nguoidung = null;
                _nguoidung = _context.Nguoidungs.Find(id);
                _nguoidung.UserName = nguoidung.UserName;
                _nguoidung.FullName = nguoidung.FullName;
                _nguoidung.Title = nguoidung.Title;
                _nguoidung.DOB = nguoidung.DOB;
                _nguoidung.Email = nguoidung.Email;
                _nguoidung.Admin = nguoidung.Admin;
                _nguoidung.Locked = nguoidung.Locked;
                if (nguoidung.Password != null)
                {
                    nguoidung.Password = _mahoaHelpers.Mahoa(nguoidung.Password);
                    _nguoidung.Password = nguoidung.Password;
                }
                _context.Update(_nguoidung);
                _context.SaveChanges();
                ret = nguoidung.NguoiDungId;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }

        public Nguoidung GetNguoidung(int id)
        {
            Nguoidung nguoidung = null;
            nguoidung = _context.Nguoidungs.Find(id);
            //nguoidung = _context.NguoiDungs.Where(x => x.NguoiDungId == id).FirstOrDefault();
            return nguoidung;
        }

        public List<Nguoidung> GetNguoiDungAll()
        {
            List<Nguoidung> list = new List<Nguoidung>();
            list = _context.Nguoidungs.ToList();
            return list;
        }

        public Nguoidung Login(ViewLogin viewLogin)
        {
            var u = _context.Nguoidungs.Where(p => p.UserName.Equals(viewLogin.UserName)
            && p.Password.Equals(_mahoaHelpers.Mahoa(viewLogin.Password))).FirstOrDefault();
            return u;
        }
    }
}

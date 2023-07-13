using ASM.Helpers;
using ASM.Models.ViewModels;

namespace ASM.Models.Services
{
    public interface IKhachhangSvc
    {
        List<Khachhang> GetKhachhangAll();
        Khachhang GetKhachhang(int id);
        int AddKhachhang(Khachhang khachhang);
        int EditKhachhang(int id, Khachhang khachhang);
        Khachhang Login(ViewWebLogin viewWebLogin);
    }
    public class KhachhangSvc : IKhachhangSvc
    {
        protected DataContext _context;
        protected IMahoaHelpers _mahoaHelpers;

        public KhachhangSvc(DataContext context, IMahoaHelpers mahoaHelpers)
        {
            _context = context;
            _mahoaHelpers = mahoaHelpers;
        }

        public int AddKhachhang(Khachhang khachhang)
        {
            int ret = 0;
            try
            {
                khachhang.Password = _mahoaHelpers.Mahoa(khachhang.Password);
                khachhang.ConfirmPassword = khachhang.ConfirmPassword;

                _context.Add(khachhang);
                _context.SaveChanges();
                ret = khachhang.KhachhangID;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }

        public int EditKhachhang(int id, Khachhang khachhang)
        {
            int ret = 0;
            try
            {
                Khachhang _khachhang = null;
                _khachhang = _context.Khachhangs.Find(id);

                _khachhang.FullName = khachhang.FullName;
                _khachhang.Ngaysinh = khachhang.Ngaysinh;
                _khachhang.PhoneNumber = khachhang.PhoneNumber;
                _khachhang.EmailAdress = khachhang.EmailAdress;
                if(_khachhang.Password != null)
                {
                    khachhang.Password = _mahoaHelpers.Mahoa(khachhang.Password);
                    _khachhang.Password = khachhang.Password;
                    _khachhang.ConfirmPassword = khachhang.Password;
                }
                _khachhang.Mota = khachhang.Mota;

                _context.Update(_khachhang);
                _context.SaveChanges();
                ret = _khachhang.KhachhangID;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }

        public Khachhang GetKhachhang(int id)
        {
            Khachhang khachhang = null;
            khachhang = _context.Khachhangs.Find(id);
            return khachhang;
        }

        public List<Khachhang> GetKhachhangAll()
        {
            List<Khachhang> list = new List<Khachhang>();
            list = _context.Khachhangs.ToList();
            return list;
        }

        public Khachhang Login(ViewWebLogin viewWebLogin)
        {
            var u = _context.Khachhangs.Where(
                p => p.EmailAdress.Equals(viewWebLogin.Email)
                && p.Password.Equals(_mahoaHelpers.Mahoa(viewWebLogin.Password))
                ).FirstOrDefault();
            return u;
        }
    }
}

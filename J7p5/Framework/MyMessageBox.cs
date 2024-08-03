using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace J7p5.Framework
{
    public static class MyMessageBox
    {
        public static void  SuccessMessage(string msg = "اطلاعات ثبت  شد")
        {
            MessageBox.Show(msg, "اطلاع", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void ValidationErrorMsg()
        {
            MessageBox.Show("اطلاعات نام ونام خانوادگی و شماره دانشجویی نمی تواند خالی باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool ConfirmMsg() 
        {
            var res = MessageBox.Show("ایا مطمعن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
            {
                return false;
            }
            return true;
        }
    }
}

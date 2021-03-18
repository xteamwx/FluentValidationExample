using FluentValidation;
using FluentValidationExample.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationExample.Model
{
    [Serializable]
    public class UserEntity
    {
        public int UserID { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string SIM { get; set; }
        public string Mail { get; set; }
    }

    /// <summary>
	/// 实体类验证
	/// </summary>
	public class UserEntityValidator : AbstractValidator<UserEntity>, IValidation
    {
        public UserEntityValidator()
        {
            RuleFor(x => x.Account).NotEmpty().WithMessage("账号不能为空")
                                                .NotEqual("admin").WithMessage("账号不能使用admin")
                                               .MaximumLength(20).WithMessage("账号长度已经超出了限制!");
            RuleFor(x => x.Password).Length(6, 16).WithMessage("密码长度最小6位，最大16位!")
                                                 .Must(x => Helper.HasValidPassword(x));
            RuleFor(x => x.ConfirmPassword)
            .Equal(x => x.Password)
            .WithMessage("2次密码不一致！");
            RuleFor(x => x.Mail).EmailAddress().WithMessage("电邮地址错误");
            RuleFor(x => x.SIM).NotEmpty()
            .Must((o, list, context) =>
            {   //定制验证器
                if (!string.IsNullOrEmpty(o.SIM))
                {
                    context.MessageFormatter.AppendArgument("SIN", o.SIM);
                    return Helper.IsValidSIN(int.Parse(o.SIM));
                }
                return true;
            })
           .WithMessage("SIM不能为空");

        }
    }
}

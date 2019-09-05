using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CRMCore
{
    public class ResultType 
    {
        public int Status { set; get; }
        public int ReturnType { set; get; }
        public string Massage { set; get; }
        public List<Tuple<string, string>> Parameters { set; get; }

    }
    public class Types
    {
        public static object GetValue(object param)
        {
            if (param == null)
                return 0;
            else
                return param;
        }
    }
    public static class ListExtensions
    {
        //   public static IEnumerable<SelectListItem> ToComboBoxListItem<T>(this List<T> SourceList, System.Linq.Expressions.Expression<Func<T, object>> d, string DisplayeMember, string ValueMember)
        public static IEnumerable<SelectListItem> ToComboBoxListItem<T>(this IQueryable<T> SourceList, System.Linq.Expressions.Expression<Func<T, object>> DisplayeMember, System.Linq.Expressions.Expression<Func<T, object>> ValueMember, string DefaultValue)
        {
            string _valueMember = "";
            if (ValueMember.Body is System.Linq.Expressions.UnaryExpression)
            {
                var expression = (System.Linq.Expressions.UnaryExpression)ValueMember.Body;

                _valueMember = ((System.Linq.Expressions.MemberExpression)expression.Operand).Member.Name;
            }
            else if (ValueMember.Body is System.Linq.Expressions.MemberExpression)
            {
                var expression = (System.Linq.Expressions.MemberExpression)ValueMember.Body;

                _valueMember = expression.Member.Name;
            }

            string _displayMember = "";
            if (DisplayeMember.Body is System.Linq.Expressions.UnaryExpression)
            {
                var expression = (System.Linq.Expressions.UnaryExpression)DisplayeMember.Body;

                _displayMember = ((System.Linq.Expressions.MemberExpression)expression.Operand).Member.Name;
            }
            else if (DisplayeMember.Body is System.Linq.Expressions.MemberExpression)
            {
                var expression = (System.Linq.Expressions.MemberExpression)DisplayeMember.Body;

                _displayMember = expression.Member.Name;
            }




            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem
            {
                Value = "0",
                Text = "انتخاب کنید"
            });
            foreach (var Record in SourceList)
            {
                list.Add(new SelectListItem
                {
                    Value = Record.GetType().GetProperty(_valueMember).GetValue(Record, null).ToString(),
                    Text = Record.GetType().GetProperty(_displayMember).GetValue(Record, null).ToString(),
                    Selected = (string.IsNullOrEmpty(DefaultValue) ? false : ((Record.GetType().GetProperty(_valueMember).GetValue(Record, null).ToString() == DefaultValue) ? true : false))
                });
            }

            return list.AsEnumerable();
        }
        public static IEnumerable<SelectListItem> ToComboBoxListItem<T>(this List<T> SourceList, System.Linq.Expressions.Expression<Func<T, object>> DisplayeMember, System.Linq.Expressions.Expression<Func<T, object>> ValueMember, Boolean isListBox, string DefaultValue)
        {


            string _valueMember = "";
            if (ValueMember.Body is System.Linq.Expressions.UnaryExpression)
            {
                var expression = (System.Linq.Expressions.UnaryExpression)ValueMember.Body;

                _valueMember = ((System.Linq.Expressions.MemberExpression)expression.Operand).Member.Name;
            }
            else if (ValueMember.Body is System.Linq.Expressions.MemberExpression)
            {
                var expression = (System.Linq.Expressions.MemberExpression)ValueMember.Body;

                _valueMember = expression.Member.Name;
            }

            string _displayMember = "";
            if (DisplayeMember.Body is System.Linq.Expressions.UnaryExpression)
            {
                var expression = (System.Linq.Expressions.UnaryExpression)DisplayeMember.Body;

                _displayMember = ((System.Linq.Expressions.MemberExpression)expression.Operand).Member.Name;
            }
            else if (DisplayeMember.Body is System.Linq.Expressions.MemberExpression)
            {
                var expression = (System.Linq.Expressions.MemberExpression)DisplayeMember.Body;

                _displayMember = expression.Member.Name;
            }



            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem
            {
                Value = "0",
                Text = "انتخاب کنید"
            });
            foreach (var Record in SourceList)
            {
                var x = Record.GetType().GetProperty(_valueMember).GetValue(Record, null);
                var y = Record.GetType().GetProperty(_displayMember).GetValue(Record, null);
                if (x != null && y != null)
                {
                    {
                        list.Add(new SelectListItem
                        {
                            Value = Record.GetType().GetProperty(_valueMember).GetValue(Record, null).ToString(),
                            Text = Record.GetType().GetProperty(_displayMember).GetValue(Record, null).ToString(),
                            Selected = (string.IsNullOrEmpty(DefaultValue) ? false : ((Record.GetType().GetProperty(_valueMember).GetValue(Record, null).ToString() == DefaultValue) ? true : false))
                        });
                    }
                }
            }

            return list.AsEnumerable();
        }
        public static IEnumerable<SelectListItem> ToComboBoxListItemNonDefault<T>(this List<T> SourceList, System.Linq.Expressions.Expression<Func<T, object>> DisplayeMember, System.Linq.Expressions.Expression<Func<T, object>> ValueMember, Boolean isListBox, string DefaultValue)
        {


            string _valueMember = "";
            if (ValueMember.Body is System.Linq.Expressions.UnaryExpression)
            {
                var expression = (System.Linq.Expressions.UnaryExpression)ValueMember.Body;

                _valueMember = ((System.Linq.Expressions.MemberExpression)expression.Operand).Member.Name;
            }
            else if (ValueMember.Body is System.Linq.Expressions.MemberExpression)
            {
                var expression = (System.Linq.Expressions.MemberExpression)ValueMember.Body;

                _valueMember = expression.Member.Name;
            }

            string _displayMember = "";
            if (DisplayeMember.Body is System.Linq.Expressions.UnaryExpression)
            {
                var expression = (System.Linq.Expressions.UnaryExpression)DisplayeMember.Body;

                _displayMember = ((System.Linq.Expressions.MemberExpression)expression.Operand).Member.Name;
            }
            else if (DisplayeMember.Body is System.Linq.Expressions.MemberExpression)
            {
                var expression = (System.Linq.Expressions.MemberExpression)DisplayeMember.Body;

                _displayMember = expression.Member.Name;
            }



            List<SelectListItem> list = new List<SelectListItem>();

            foreach (var Record in SourceList)
            {
                list.Add(new SelectListItem
                {
                    Value = Record.GetType().GetProperty(_valueMember).GetValue(Record, null).ToString(),
                    Text = Record.GetType().GetProperty(_displayMember).GetValue(Record, null).ToString(),
                    Selected = (string.IsNullOrEmpty(DefaultValue) ? false : ((Record.GetType().GetProperty(_valueMember).GetValue(Record, null).ToString() == DefaultValue) ? true : false))
                });
            }

            return list.AsEnumerable();
        }
    }



    //string json = w.JSON;
    //   var serializer = new JavaScriptSerializer();
    //   serializer.RegisterConverters(new[] { new DynamicJsonConverter() });

    //   DynamicJsonConverter.DynamicJsonObject obj = (DynamicJsonConverter.DynamicJsonObject)serializer.Deserialize(json, typeof(object));



    //    public static object GetProperty(object o, string member)
    //{
    //    if(o == null) throw new ArgumentNullException("o");
    //    if(member == null) throw new ArgumentNullException("member");
    //    Type scope = o.GetType();
    //    IDynamicMetaObjectProvider provider = o as IDynamicMetaObjectProvider;
    //    if(provider != null)
    //    {
    //        ParameterExpression param = Expression.Parameter(typeof(object));
    //        DynamicMetaObject mobj = provider.GetMetaObject(param);
    //        GetMemberBinder binder = (GetMemberBinder)Microsoft.CSharp.RuntimeBinder.Binder.GetMember(0, member, scope, new CSharpArgumentInfo[]{CSharpArgumentInfo.Create(0, null)});
    //        DynamicMetaObject ret = mobj.BindGetMember(binder);
    //        BlockExpression final = Expression.Block(
    //            Expression.Label(CallSiteBinder.UpdateLabel),
    //            ret.Expression
    //        );
    //        LambdaExpression lambda = Expression.Lambda(final, param);
    //        Delegate del = lambda.Compile();
    //        return del.DynamicInvoke(o);
    //    }else{
    //        return o.GetType().GetProperty(member, BindingFlags.Public | BindingFlags.Instance).GetValue(o, null);
    //    }
    //}
}

using DECIS.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;

namespace DECIS.PageLogic.ControlContainerBase
{
    public abstract class ControlContainer
    {
        private Page _page;

        public ControlContainer(Page page)
        {
            _page = page;
        }
        
        public virtual void InitializeControls(bool masterPage = true)
        {
            var fieldArray = GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            for (int i = 0; i < fieldArray.Length; i++)
            {
                //Try to find a control matching the property name
                var control = masterPage ? FindControl.Find($"{fieldArray[i].Name.Replace("_", "")}", _page) : FindControl.FindNM($"{fieldArray[i].Name.Replace("_", "")}", _page);
                if (control == null)
                    continue; //Can't find the control, just skip, might not be visible/rendered yet

                Type fieldType = fieldArray[i].FieldType;
                //If control being in list is helpful, e.g. for clearing all textboxes, create a property with a name that matches the control class. E.g. List<TextBox> TextBox;
                IList list = GetType().GetProperty(fieldType.Name, BindingFlags.Instance)?.GetValue(this) as IList;
                list?.Add(control);
                fieldArray[i].SetValue(this, Convert.ChangeType(control, fieldType));
            }
        }
    }
}
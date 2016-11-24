using PCLConstruct.Client.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using PCLConstruct.Client.Controls.Interfaces;

namespace PCLConstruct.Client.Controls.Behaviors
{
    public class FormEntryBehavior 
    {
        public class TextBehavior : Behavior<FormEntry>
        {
            protected override void OnAttachedTo(FormEntry entry)
            {
                entry.TextChanged += OnEntryTextChanged;
                base.OnAttachedTo(entry);
            }

            protected override void OnDetachingFrom(FormEntry entry)
            {
                entry.TextChanged -= OnEntryTextChanged;
                base.OnDetachingFrom(entry);
            }

            void OnEntryTextChanged(object sender, TextChangedEventArgs args)
            {
                ((IValidatable)sender).evaluateValidity();
            }
        }

        public class DropDownListBehavior : Behavior<FormDropDownList>
        {
            protected override void OnAttachedTo(FormDropDownList entry)
            {
                entry.SelectedIndexChanged += OnSelectedIndexChanged;
                base.OnAttachedTo(entry);
            }

            protected override void OnDetachingFrom(FormDropDownList entry)
            {
                entry.SelectedIndexChanged -= OnSelectedIndexChanged;
                base.OnDetachingFrom(entry);
            }

            void OnSelectedIndexChanged(object sender, EventArgs args)
            {
                ((IValidatable)sender).evaluateValidity();
            }
        }

        public class ToggleBehavior : Behavior<FormBoolean>
        {
            protected override void OnAttachedTo(FormBoolean entry)
            {
                entry.Toggled += OnToggleChanged;
                base.OnAttachedTo(entry);
            }

            protected override void OnDetachingFrom(FormBoolean entry)
            {
                entry.Toggled -= OnToggleChanged;
                base.OnDetachingFrom(entry);
            }

            void OnToggleChanged(object sender, EventArgs args)
            {
                ((IValidatable)sender).evaluateValidity();
            }
        }

    }

   
}

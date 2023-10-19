using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;

namespace dobra3.TemplateSelectors
{
    public abstract class GenericTemplateSelector<TItem> : IDataTemplate
    {
        public Control? Build(object? param)
        {
            if (param is not TItem item)
                throw new ArgumentException(nameof(param));

            var template = SelectTemplateCore(item);
            return template?.Build(item);
        }

        public bool Match(object? data)
        {
            if (data is not TItem item)
                return false;

            return SelectTemplateCore(item) != null;
        }

        protected abstract IDataTemplate? SelectTemplateCore(TItem? item);
    }
}
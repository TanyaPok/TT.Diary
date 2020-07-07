using System;
using System.Collections.Generic;
using System.Linq;

namespace TT.Diary.DataAccessLogic.Model.Framework
{
    public abstract class AbstractComposite : AbstractComponent
    {
        public abstract IEnumerable<AbstractComponent> Children { get; }

        public virtual bool Has(Func<AbstractComposite, bool> func)
        {
            if (func.Invoke(this))
            {
                return true;
            }

            var has = false;

            foreach (var child in Children.OfType<AbstractComposite>())
            {
                if (child.Has(func))
                {
                    has = true;
                    break;
                }
            }

            return has;
        }

        public abstract void Add(AbstractComponent component);

        public abstract void Remove(AbstractComponent component);
    }
}
﻿using App.Core.Interface;
using App.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Decorator
{
    public abstract class WorkerDecorator : IWorker
    {
        public IWorker worker;

        public WorkerDecorator(IWorker worker)
        {
            this.worker = worker;
        }

        public void workPlace(Restaurant newRestaurant)
        {
            this.worker.workPlace(newRestaurant);
        }

        public void makeDish()
        {
            this.worker.makeDish();
        }

        public IWorker removeRole(string role)
        {
            if(this.worker.GetType().Equals(role))
            {
                return ((WorkerDecorator) this.worker).removeRole(role);
            } else
            {
                if(!(this.worker is AbstractWorker))
                {
                    this.worker = ((WorkerDecorator)this.worker).removeRole(role);
                }
                return this;
            }
        }

        public IWorker getPlain()
        {
            if(this.worker is WorkerDecorator)
            {
                return ((WorkerDecorator)this.worker).getPlain();
            } else
            {
                return this.worker;
            }
        }

        public WorkerDecorator getRole(string role)
        {
            var tt = this.GetType().IsAssignableFrom(Type.GetType(role));
            if(this.GetType().IsAssignableFrom(Type.GetType(role)))
            {
               return this;
            }
            if(this.worker is WorkerDecorator)
            {
                return ((WorkerDecorator)this.worker).getRole(role);
            }
            return null;
        }

        public WorkerDecorator getParent(string role)
        {
            if (this.worker.GetType().IsAssignableFrom(Type.GetType(role)))
            {
                return this;
            }
            if (this.worker is WorkerDecorator)
            {
                return ((WorkerDecorator)this.worker).getParent(role);
            }
            return null;
        }
    }
}

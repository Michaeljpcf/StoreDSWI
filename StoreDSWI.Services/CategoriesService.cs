﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
//
using StoreDSWI.Database;
using StoreDSWI.Entities;

namespace StoreDSWI.Services
{
    public class CategoriesService
    {
        #region Singleton
        public static CategoriesService Instance
        {
            get
            {
                if (instance == null) instance = new CategoriesService();
                return instance;
            }
        }
        private static CategoriesService instance { get; set; }

        private CategoriesService()
        {
        }
        #endregion

        public Category GetCategory(int ID)
        {
            using (var context = new CBContext())
            {
                return context.Categories.Find(ID);
            }
        }

        public int GetCategoriesCount(string search)
        {
            using (var context = new CBContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return context.Categories.Where(category => category.Name != null &&
                        category.Name.ToLower().Contains(search.ToLower())).Count();
                }
                else
                {
                    return context.Categories.Count(); ;
                }                
            }
        }

        public List<Category> GetAllCategories()
        {
            using (var context = new CBContext())
            {
                return context.Categories.ToList();
            }
        }

        public List<Category> GetCategories(string search, int pageNo)
        {
            int pageSize = 3;
            using (var context = new CBContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return context.Categories.Where(category => category.Name != null && 
                        category.Name.ToLower().Contains(search.ToLower()))
                        .OrderBy(x => x.ID)
                        .Skip((pageNo - 1) * pageSize)
                        .Take(pageSize)
                        .Include(x => x.Products)
                        .ToList();
                }
                else
                {
                    return context.Categories
                        .OrderBy(x => x.ID)
                        .Skip((pageNo - 1) * pageSize)
                        .Take(pageSize)
                        .Include(x => x.Products)
                        .ToList();
                }
            }
        }

        public List<Category> GetFeaturedCategories()
        {
            using (var context = new CBContext())
            {
                return context.Categories.Where(x => x.isFeatured && x.ImageURL != null).ToList();
            }
        }

        public void SaveCategory(Category category)
        {
            using (var context = new CBContext())
            {
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }

        public void UpdateCategory(Category category)
        {
            using (var context = new CBContext())
            {
                context.Entry(category).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Category GetCategory(object categoryID)
        {
            throw new NotImplementedException();
        }

        public void DeleteCategory(int ID)
        {
            using (var context = new CBContext())
            {
                var category = context.Categories.Where(x=>x.ID == ID).Include(x=>x.Products).FirstOrDefault();

                context.Products.RemoveRange(category.Products); //eliminé los productos de la categoría.
                context.Categories.Remove(category);
                context.SaveChanges();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ExpressDelivery.Domain.Entities;

/// <summary>
/// Сводное описание для Repository
/// </summary>
public class Repository
{
    public static IQueryable<TEntity> Select<TEntity>() where TEntity : class
    {
        // Переменная, представляющая модель базы данных Платежи
        strExpressDeliveryEntities context = new strExpressDeliveryEntities();
        // Загрузка данных с помощью универсального метода Set
        return context.Set<TEntity>();
    }
    public static void Insert<TEntity>(TEntity entity) where TEntity : class
    {
        // Переменная, представляющая модель базы данных Платежи
        strExpressDeliveryEntities context = new strExpressDeliveryEntities();
        context.Entry(entity).State = EntityState.Added;
        context.SaveChanges();
    }

    /// Запись нескольких полей в БД
    public static void Inserts<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
    {
        // Переменная, представляющая модель базы данных Платежи
        strExpressDeliveryEntities context = new strExpressDeliveryEntities();
        //Отключаем отслеживание и проверку изменений для оптимизации вставки множества полей
        context.Configuration.AutoDetectChangesEnabled = false;
        context.Configuration.ValidateOnSaveEnabled = false;

        foreach (TEntity entity in entities)
            context.Entry(entity).State = EntityState.Added;
        context.SaveChanges();

        context.Configuration.AutoDetectChangesEnabled = true;
        context.Configuration.ValidateOnSaveEnabled = true;
    }
    public static void Update<TEntity>(TEntity entity, DbContext context) where TEntity : class
    {
        context.Entry<TEntity>(entity).State = EntityState.Modified;
        context.SaveChanges();
    }
    public static void Delete<TEntity>(TEntity entity) where TEntity : class
    {
        // Переменная, представляющая модель базы данных Платежи
        strExpressDeliveryEntities context = new strExpressDeliveryEntities();
        context.Entry<TEntity>(entity).State = EntityState.Deleted;
        context.SaveChanges();
    }
}
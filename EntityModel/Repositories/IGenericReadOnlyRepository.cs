using EntityModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Repositories
{
    /// <summary>
    /// Cette interface générique défini les méthodes de lecture uniquement.
    /// </summary>
    /// <typeparam name="TEntity">L'entité à manipuler</typeparam>
    public interface IGenericReadOnlyRepository<TEntity> where TEntity : AbstractEntity
    {
        /// <summary>
        /// Retourne une entité si elle existe
        /// </summary>
        /// <param name="id">identifiant de l'entité</param>
        /// <returns>L'entité trouvée, ou null</returns>
        public TEntity GetById(int id);
        /// <summary>
        /// Retourne la totalité des entitées
        /// </summary>
        /// <returns></returns>
        public IList<TEntity> GetAll();
        /// <summary>
        /// Retourne la toatalité des entités respectant une expression
        /// </summary>
        /// <param name="expression">Exepression lambda</param>
        /// <returns>Liste d'entités</returns>
        public IList<TEntity> FindAllWhere(Expression<Func<TEntity, bool>> expression);
    }
}

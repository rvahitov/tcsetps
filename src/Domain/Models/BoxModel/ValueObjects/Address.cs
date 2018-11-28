using System;
using System.Collections.Generic;
using Akkatecture.ValueObjects;
using JetBrains.Annotations;

namespace Correct.Storage.Domain.Models.BoxModel.ValueObjects
{
    public class Address : ValueObject
    {
        public Address([NotNull] string room, [NotNull] string rack, [NotNull] string shelf)
        {
            if (string.IsNullOrEmpty(room)) throw new ArgumentException("Value cannot be null or empty.", nameof(room));
            if (string.IsNullOrEmpty(rack)) throw new ArgumentException("Value cannot be null or empty.", nameof(rack));
            if (string.IsNullOrEmpty(shelf))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(shelf));
            }

            Room = room;
            Rack = rack;
            Shelf = shelf;
        }

        /// <summary>
        ///     Помещение
        /// </summary>
        public string Room { get; }

        /// <summary>
        ///     Стеллаж
        /// </summary>
        public string Rack { get; }

        /// <summary>
        ///     Полка
        /// </summary>
        public string Shelf { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Room;
            yield return Rack;
            yield return Shelf;
        }
    }
}
﻿using Simoja.Domain.Entity;

namespace Simoja.Repository;

public interface ILokasiIzin
{
    IQueryable<LokasiIzin> LokasiIzins { get; }
}

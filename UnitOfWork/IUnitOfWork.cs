﻿using POSWebApp.Repositories.Domain;

namespace POSWebApp.UnitOfWork;

public interface IUnitOfWork
{
    ICashierRepository CashierRepository { get; }
    void Commit();
    void Roolback();
}

using CommerceSystem.Application.Features.Stocks.Dtos;
using CommerceSystem.Application.Interfaces;
using CommerceSystem.Application.Interfaces.Repositories;
using CommerceSystem.Application.Interfaces.Services;
using CommerceSystem.Common;
using CommerceSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;
        private readonly IStockMovementRepository _stockMovementRepository;
        private readonly IStockBatchRepository _stockBatchRepository;
        private readonly IProductVariantRepository _productVariantRepository;
        private readonly IUnitOfWork _unitOfWork;

        public StockService(
            IStockRepository stockRepository,
            IStockMovementRepository stockMovementRepository,
            IStockBatchRepository stockBatchRepository,
            IProductVariantRepository productVariantRepository,
            IUnitOfWork unitOfWork)
        {
            _stockRepository = stockRepository;
            _stockMovementRepository = stockMovementRepository;
            _stockBatchRepository = stockBatchRepository;
            _productVariantRepository = productVariantRepository;
            _unitOfWork = unitOfWork;
        }

        public Task DecreaseAsync(Guid branchId, Guid productVariantId, int quantity, StockMovementType movementType, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task IncreaseAsync(
            Guid branchId,
            List<IncreaseStockItemDto> items,
            StockMovementType movementType,
            string? note,
            CancellationToken cancellationToken)
        {
            foreach (var item in items)
            {
                var productVariant = await _productVariantRepository.GetByIdAsync(item.ProductVariantId, cancellationToken);

                if (productVariant is null)
                    throw new Exception("Product variant not found.");
                if (item.Quantity < 1)
                    throw new Exception("Product variant quantity less than 1");

                var stock = await _stockRepository.GetByBranchAndProductVariantAsync(branchId, item.ProductVariantId, cancellationToken);

                if (stock is null)
                {
                    stock = new Stock
                    {
                        Id = Guid.NewGuid(),
                        BranchId = branchId,
                        ProductVariantId = item.ProductVariantId,
                        Quantity = item.Quantity
                    };

                    await _stockRepository.AddAsync(stock, cancellationToken);
                }
                else
                {
                    stock.Quantity += item.Quantity;
                    _stockRepository.Update(stock);
                }

                var stockBatch = new StockBatch
                {
                    Id = Guid.NewGuid(),
                    BranchId = branchId,
                    ProductVariantId = item.ProductVariantId,
                    InitialQuantity = item.Quantity,
                    RemainingQuantity = item.Quantity,
                    UnitCost = productVariant.PurchasePrice,
                    CreatedAtUtc = DateTime.UtcNow
                };

                await _stockBatchRepository.AddAsync(stockBatch, cancellationToken);

                var movement = new StockMovement
                {
                    Id = Guid.NewGuid(),
                    BranchId = branchId,
                    ProductVariantId = item.ProductVariantId,
                    QuantityChange = item.Quantity,
                    MovementType = movementType,
                    Note = note,
                    CreatedAtUtc = DateTime.UtcNow
                };

                await _stockMovementRepository.AddAsync(movement, cancellationToken);
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}

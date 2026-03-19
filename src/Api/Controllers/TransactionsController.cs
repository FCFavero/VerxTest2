using Application.DTOs;
using Application.UseCases;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace VertxTest.Controllers;

[ApiController]
[Route("transactions")]
public class TransactionsController : ControllerBase
{
    private readonly CreateTransactionUseCase _useCase;

    public TransactionsController(CreateTransactionUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTransactionRequest request)
    {
        await _useCase.ExecuteAsync(request.Amount, (TransactionType)request.Type);

        return Ok();
    }
}
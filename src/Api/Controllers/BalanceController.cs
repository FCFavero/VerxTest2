using Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace VertxTest.Controllers;

[ApiController]
[Route("balance")]
public class BalanceController : ControllerBase
{
    private readonly GetDailyBalanceUseCase _useCase;

    public BalanceController(GetDailyBalanceUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpGet("{date}")]
    public async Task<IActionResult> Get(DateTime date)
    {
        var result = await _useCase.ExecuteAsync(date);

        return Ok(result);
    }
}
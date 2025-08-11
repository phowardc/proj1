using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using zelis.Api.Data;
using zelis.Api.Models;
using zelis.Shared.Dtos;
using zelis.Shared.Statuses;

namespace Zelis.Api.Controllers;

[ApiController]
[Route("api/CommunicationType")]
//[IgnoreAntiforgeryToken] // keep on while testing to avoid antiforgery 400/403
public class CommunicationTypeController : ControllerBase
{
    private readonly AppDbContext _db;

    public CommunicationTypeController(AppDbContext db)
    {
        _db = db;
        Console.WriteLine("🟢 CommunicationTypeController constructed");
    }

    // GET api/CommunicationType/{typeCode}/exists
    [HttpGet("{typeCode}/exists")]
    public async Task<IActionResult> Exists(string typeCode)
    {
        Console.WriteLine($"➡️  Exists() called with typeCode='{typeCode}'");
        var exists = await _db.CommunicationType
            .AsNoTracking()
            .AnyAsync(t => t.TypeCode == typeCode);
        Console.WriteLine($"⬅️  Exists() returning {(exists ? 200 : 404)} for '{typeCode}'");
        return exists ? Ok() : NotFound();
    }

    

    // GET api/CommunicationType/status-options
    [HttpGet("status-options")]
    public ActionResult<IEnumerable<StatusOptionDto>> GetStatusOptions()
    {
        Console.WriteLine("➡️  GetStatusOptions() called");
        var result = Ok(GlobalStatusCatalog.All);
        Console.WriteLine($"⬅️  GetStatusOptions() returning {GlobalStatusCatalog.All.Length} options");
        return result;
    }

   // GET api/CommunicationType 
   [HttpGet]
    public async Task<ActionResult<IEnumerable<CommunicationType>>> GetTypes()
    {
        var communicationTypes = await _db.CommunicationType
            .ToListAsync();

        var statuses = await _db.CommunicationTypeStatus.AsNoTracking().ToListAsync();
        var statusList = new List<CommunicationTypeStatus>();

        foreach (var t in communicationTypes){
        t.AllowedStatuses = statuses.Where(s => s.TypeCode == t.TypeCode).ToList();
        statusList = t.AllowedStatuses;
        }

 

        var response = communicationTypes.Select(communicationType => new CommunicationType
        {
            TypeCode = communicationType.TypeCode,
            DisplayName = communicationType.DisplayName,
            AllowedStatuses = statusList
            
            // communicationType.AllowedStatuses.Select(status => new CommunicationTypeStatus
            // {
            //     TypeCode = status.TypeCode,
            //     Description = status.Description,
            //     StatusCode = status.StatusCode
            // }).ToList()

        });

        //Console.WriteLine($"Response {communicationType.AllowedStatuses}");
        return(Ok(response));
    }

    // POST api/CommunicationType (simple insert to prove DB writes)
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CommunicationType dto)
    {
        if (dto == null)
        {
            return BadRequest("Body required.");
        }

        // Minimal insert (no validation, no statuses)
        _db.CommunicationType.Add(new CommunicationType
        {
            TypeCode = dto.TypeCode ?? string.Empty,
            DisplayName = dto.DisplayName ?? string.Empty,
            AllowedStatuses = dto.AllowedStatuses.Select(commstatus => new CommunicationTypeStatus{
                TypeCode = dto.TypeCode,
                StatusCode = commstatus.StatusCode,
                Description = commstatus.Description
            }).ToList()
        });

        try
        {
            var saved = await _db.SaveChangesAsync();
            return Ok(dto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    // PUT api/CommunicationType/{typeCode}
    [HttpPut("{typeCode}")]
    public async Task<IActionResult> Replace(string typeCode, [FromBody] CreateCommunicationTypeDto dto)
    {
        Console.WriteLine($"➡️  Replace() called routeTypeCode='{typeCode}', bodyTypeCode='{dto?.TypeCode}'");

        if (dto is null)
        {
            Console.WriteLine(" Replace() -> 400 Body required");
            return BadRequest("Body required.");
        }
        if (!string.Equals(dto.TypeCode, typeCode, StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine(" Replace() -> 400 Route/body typeCode mismatch");
            return BadRequest("TypeCode in route and body must match.");
        }
        if (string.IsNullOrWhiteSpace(dto.DisplayName))
        {
            Console.WriteLine("❌Replace() -> 400 DisplayName required");
            return BadRequest("DisplayName is required.");
        }
        dto.AllowedStatusCodes ??= new();

        var t = await _db.CommunicationType.FirstOrDefaultAsync(x => x.TypeCode == typeCode);
        if (t is null)
        {
            Console.WriteLine($" Replace() -> 404 '{typeCode}' not found");
            return NotFound();
        }

        using var tx = await _db.Database.BeginTransactionAsync();
        try
        {
            t.DisplayName = dto.DisplayName;

            var existing = await _db.CommunicationTypeStatus
                .Where(s => s.TypeCode == typeCode)
                .ToListAsync();
            _db.CommunicationTypeStatus.RemoveRange(existing);

            foreach (var code in dto.AllowedStatusCodes.Distinct(StringComparer.OrdinalIgnoreCase))
            {
                GlobalStatusCatalog.Descriptions.TryGetValue(code, out var d);
                _db.CommunicationTypeStatus.Add(new CommunicationTypeStatus
                {
                    TypeCode = typeCode,
                    StatusCode = code,
                    Description = d ?? string.Empty
                });
            }

            var saved = await _db.SaveChangesAsync();
            await tx.CommitAsync();
            Console.WriteLine($"✅ Replace() saved {saved} change(s) for '{typeCode}'");
            return NoContent();
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            Console.WriteLine($"💥 Replace() exception: {ex}");
            return StatusCode(500, ex.Message);
        }
    }
}

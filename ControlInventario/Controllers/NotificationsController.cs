/*using ControlInventario.WebApi.Controllers;
using ControlInventario.WebApi.Filter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControlInventario.WebApi.Controllers;

[Authorize]
[ApiController]
[HttpClientExceptionFilter]
[Route("[controller]")]
public class NotificationsController : BaseController<INotificationRepository>
{
    public NotificationsController(INotificationRepository repository) : base(repository) { }

    [HttpPut]
    public async Task<IActionResult> MarkAsSeen(int notificationId, CancellationToken cancellationToken)
        => Ok(await repository.MarkAsSeen(notificationId, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetNotificationsListAsync(short page, CancellationToken cancellationToken)
        => Ok(await repository.GetNotificationsListAsync(page, cancellationToken));

    [HttpPost]
    public async Task<IActionResult> GetNotificationMessageAsync(Notification not, CancellationToken cancellationToken)
        => Ok(await repository.ReceiveNotificationFromRabbit(not, cancellationToken));
}*/
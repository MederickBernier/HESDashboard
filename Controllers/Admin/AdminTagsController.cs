using HESDashboard.Data;
using HESDashboard.Models;
using HESDashboard.Services;
using Microsoft.AspNetCore.Mvc;

namespace HESDashboard.Controllers.Admin;
public class AdminTagsController : Controller {
    private readonly ITagService _tagService;

    public AdminTagsController(ITagService tagService) {
        _tagService = tagService;
    }

    public async Task<IActionResult> Index() {
        var tags = await _tagService.GetAllAsync();
        return View(tags);
    }

    public IActionResult Create() => View(new Tag());

    [HttpPost]
    public async Task<IActionResult> Create(Tag tag) {
        if (!ModelState.IsValid) return View(tag);

        await _tagService.CreateAsync(tag);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id) {
        var tag = await _tagService.GetByIdAsync(id);
        return tag is null ? NotFound() : View(tag);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Tag tag) {
        if (!ModelState.IsValid) return View(tag);

        await _tagService.UpdateAsync(tag);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id) {
        await _tagService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}

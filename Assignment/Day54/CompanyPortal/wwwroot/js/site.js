function showToast(selector) {
  const toastElement = selector ? document.querySelector(selector) : null;

  if (!toastElement || typeof bootstrap === "undefined") {
    return;
  }

  bootstrap.Toast.getOrCreateInstance(toastElement).show();
}

document.addEventListener("DOMContentLoaded", () => {
  document
    .querySelectorAll("[data-toast-auto-show='true']")
    .forEach((toastElement) => {
      bootstrap.Toast.getOrCreateInstance(toastElement).show();
    });
});

document.addEventListener("click", (event) => {
  const trigger = event.target.closest("[data-toast-target]");

  if (!trigger) {
    return;
  }

  showToast(trigger.getAttribute("data-toast-target"));
});

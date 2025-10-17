window.onload = function () {
    const link = document.createElement("a");
    link.href = "/upload-cnab";
    link.textContent = "Upload CNAB";
    link.style = "position:absolute;top:10px;right:20px;font-weight:bold;";
    document.body.appendChild(link);
};

var open = document.getElementById('open');
if (open)
    open.addEventListener('click', function () {
        document.querySelector('.bg-modal').style.display = 'flex';
        document.querySelector('.job_title').val("");
    });

document.querySelector('.close').addEventListener('click', function () {
    document.querySelector('.bg-modal').style.display = 'none';
});
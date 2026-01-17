// site.js
document.addEventListener("DOMContentLoaded", function(){
  // TYPEWRITER (on index)
  const t = document.querySelector('[data-typewriter]');
  if(t){
    const arr = JSON.parse(t.dataset.typewriter);
    let i=0, j=0;
    function step(){
      const full = arr[i];
      t.textContent = full.substring(0, j);
      j++;
      if(j>full.length+10){ j=0; i=(i+1)%arr.length; }
      setTimeout(step, 80);
    }
    step();
  }

  // Project modal fill
  const modal = document.getElementById('projectModal');
  if(modal){
    modal.addEventListener('show.bs.modal', function(e){
      const btn = e.relatedTarget;
      modal.querySelector('.modal-title').textContent = btn.dataset.title || '';
      modal.querySelector('.modal-body p').textContent = btn.dataset.desc || '';
    });
  }
  
  // Contact toast show (server sets data-show)
  const toastEl = document.getElementById('contactSuccess');
  if(toastEl){
    const show = toastEl.dataset.show;
    if(show === 'true'){
      const bs = bootstrap.Toast.getOrCreateInstance(toastEl);
      bs.show();
    }
  }
  
});

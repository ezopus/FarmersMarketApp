let orderBtn = document.getElementById('ordersBtn')
let orderBtnArrow = document.getElementById('btnGroupDrop')
let openOrdersTable = document.getElementById('openOrdersTable')
let completedOrdersTable = document.getElementById('completedOrdersTable')
let cancelledOrdersTable = document.getElementById('cancelledOrdersTable')
let pendingOrdersTable = document.getElementById('pendingOrdersTable')


document.getElementById('allOrdersBtn').addEventListener('click', () => {
    openOrdersTable.classList.remove('visually-hidden')
    completedOrdersTable.classList.remove('visually-hidden')
    cancelledOrdersTable.classList.remove('visually-hidden')
    pendingOrdersTable.classList.remove('visually-hidden')

    orderBtn.classList.remove('btn-info')
    orderBtn.classList.remove('btn-warning')
    orderBtn.classList.remove('btn-danger')
    orderBtn.classList.remove('btn-success')
    orderBtn.classList.add('btn-primary')

    orderBtnArrow.classList.remove('btn-info')
    orderBtnArrow.classList.remove('btn-warning')
    orderBtnArrow.classList.remove('btn-danger')
    orderBtnArrow.classList.remove('btn-success')
    orderBtnArrow.classList.add('btn-primary')

    orderBtn.textContent = 'All orders'
})

document.getElementById('openOrdersBtn').addEventListener('click', () => {
    openOrdersTable.classList.remove('visually-hidden')
    pendingOrdersTable.classList.remove('visually-hidden')
    completedOrdersTable.classList.add('visually-hidden')
    cancelledOrdersTable.classList.add('visually-hidden')

    orderBtn.classList.remove('btn-primary')
    orderBtn.classList.remove('btn-success')
    orderBtn.classList.remove('btn-warning')
    orderBtn.classList.remove('btn-danger')
    orderBtn.classList.add('btn-info')

    orderBtnArrow.classList.remove('btn-primary')
    orderBtnArrow.classList.remove('btn-success')
    orderBtnArrow.classList.remove('btn-warning')
    orderBtnArrow.classList.remove('btn-danger')
    orderBtnArrow.classList.add('btn-info')

    orderBtn.textContent = 'Current order'
})

document.getElementById('completedOrderBtn').addEventListener('click', () => {
    openOrdersTable.classList.add('visually-hidden')
    completedOrdersTable.classList.remove('visually-hidden')
    completedOrdersTable.classList.add('visually-hidden')
    pendingOrdersTable.classList.add('visually-hidden')

    orderBtn.classList.remove('btn-primary')
    orderBtn.classList.remove('btn-info')
    orderBtn.classList.remove('btn-warning')
    orderBtn.classList.remove('btn-danger')
    orderBtn.classList.add('btn-success')

    orderBtnArrow.classList.remove('btn-primary')
    orderBtnArrow.classList.remove('btn-info')
    orderBtnArrow.classList.remove('btn-warning')
    orderBtnArrow.classList.remove('btn-danger')
    orderBtnArrow.classList.add('btn-success')

    orderBtn.textContent = 'Complete orders'
})

document.getElementById('cancelledOrdersBtn').addEventListener('click', () => {
    openOrdersTable.classList.add('visually-hidden')
    completedOrdersTable.classList.add('visually-hidden')
    pendingOrdersTable.classList.add('visually-hidden')
    cancelledOrdersTable.classList.remove('visually-hidden')

    orderBtn.classList.remove('btn-primary')
    orderBtn.classList.remove('btn-success')
    orderBtn.classList.remove('btn-info')
    orderBtn.classList.remove('btn-warning')
    orderBtn.classList.add('btn-danger')

    orderBtnArrow.classList.remove('btn-primary')
    orderBtnArrow.classList.remove('btn-success')
    orderBtnArrow.classList.remove('btn-info')
    orderBtnArrow.classList.remove('btn-warning')
    orderBtnArrow.classList.add('btn-danger')

    orderBtn.textContent = 'Cancelled orders'
})


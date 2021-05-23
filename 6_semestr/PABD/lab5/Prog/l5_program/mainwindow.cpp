#include "mainwindow.h"
#include "ui_mainwindow.h"

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);

    mainMenu = new QMenu(tr("&Меню"), this);
    mainMenuTables = new QMenu(tr("&Основные таблицы"), this);
    otherMenuTables = new QMenu(tr("&Справочники"), this);

    actAuthorisation = new QAction(tr("&Авторизация"), this);

    actUch_Load = new QAction(tr("&Учебная нагрузка"), this);

    actCourse = new QAction(tr("&Курс"), this);
    actDiscipline = new QAction(tr("&Дисциплина"), this);
    actSpeciality = new QAction(tr("&Специальность"), this);
    actUch_Plan = new QAction(tr("&Учебный план"), this);
    actGruppa = new QAction(tr("&Группа"), this);
    actGupr = new QAction(tr("&ГУПР"), this);
    actGupr_elem = new QAction(tr("&Элемент ГУПР"), this);
    actKafedra = new QAction(tr("&Кафедра"), this);
    actKaf_Rasp = new QAction(tr("&Кафедра распределения"), this);
    actSemestr = new QAction(tr("&Семестр"), this);
    actNumber_Weeks = new QAction(tr("&Количество недель"), this);

    mainMenu->addAction(actAuthorisation);

    mainMenuTables->addAction(actUch_Load);
    mainMenuTables->addAction(actGruppa);
    mainMenuTables->addAction(actKaf_Rasp);

    otherMenuTables->addAction(actCourse);
    otherMenuTables->addAction(actDiscipline);
    otherMenuTables->addAction(actSpeciality);
    otherMenuTables->addAction(actUch_Plan);
    otherMenuTables->addAction(actGupr);
    otherMenuTables->addAction(actGupr_elem);
    otherMenuTables->addAction(actKafedra);
    otherMenuTables->addAction(actSemestr);
    otherMenuTables->addAction(actNumber_Weeks);

    ui->menubar->addMenu(mainMenu);
    ui->menubar->addMenu(mainMenuTables);
    ui->menubar->addMenu(otherMenuTables);

    formAutorization = new Authorization();
    formUch_Plan = new Uch_Plan(db);
    formGupr = new Gupr(db);
    formGruppa = new Gruppa(db);
    formAdd = new ExtensibleAdd();
    formKaf = new Kaf_Rasp(db);

    connect(formAutorization, SIGNAL(sendConnect()), this,
    SLOT(Connect()));
    connect(formAutorization, SIGNAL(sendDisconnect()),
    this, SLOT(Disconnect()));

    connect(formAdd, SIGNAL(sendPositive()), this,
    SLOT(Add()));
    connect(formAdd, SIGNAL(sendNegative()),
    this, SLOT(Dismiss()));

    connect(ui->menubar, SIGNAL(triggered(QAction*)), this, SLOT(OpenF(QAction*)));

    formAutorization->show();
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::OpenF(QAction* a)
{
    qDebug() << const_hash(a->text().toStdString().c_str());
    selectedTable = a->text();
    switch (const_hash(selectedTable.toStdString().c_str())) {
        case 1105689965: formAutorization->show();
            break;
        case 3566738188: selectTable("course");
            break;
        case 34458455: selectTable("discipline");
            break;
        case 2821064468: selectTable("speciality");
            break;
        case 2581877950: selectTable("gupr_elem");
            break;
    case 1721633621:
        formUch_Plan->Update();
        formUch_Plan->show();
        break;
    case 1202426404:
        selectTable("kafedra");
        break;
    case 4111733963:
        selectTable("number_weeks");
        break;
    case 3415898536:
        selectTable("semestr");
        break;
    case 1436716544:
        formGupr->Update();
        formGupr->show();
        break;
    case 3862366129:
        formGruppa->SetDB(db);
        formGruppa->Update();
        formGruppa->show();
        break;
     case 2958382714:
        formKaf->Update();
        formKaf->show();
    }

}

void MainWindow::selectTable(QString nameTable)
{
    ui->tableView->show();
    table = new QSqlRelationalTableModel(0, db);
    table->setTable(nameTable);
    ui->tableView->setModel(table);
    ui->tableView->showColumn(0);
    ui->tableView->horizontalHeader()->setSectionResizeMode(QHeaderView::Stretch);

    if(nameTable == "discipline")
    {
        table->setHeaderData(1, Qt::Horizontal, QObject::tr("Наименование дисциплины"), Qt::DisplayRole);
        ui->tableView->hideColumn(0);
    }

    else if(nameTable == "course")
    {
        table->setHeaderData(0, Qt::Horizontal, QObject::tr("Номер курса"), Qt::DisplayRole);
    }

    else if(nameTable == "number_weeks")
    {
        table->setHeaderData(0, Qt::Horizontal, QObject::tr("Количество недель"), Qt::DisplayRole);
    }

    else if(nameTable == "speciality")
    {
        table->setHeaderData(1, Qt::Horizontal, QObject::tr("Специальность"), Qt::DisplayRole);
    }

    else if(nameTable == "gupr_elem")
    {
        table->setHeaderData(1, Qt::Horizontal, QObject::tr("Элемент ГУПР"), Qt::DisplayRole);
    }

    else if(nameTable == "kafedra")
    {
        table->setHeaderData(1, Qt::Horizontal, QObject::tr("Кафедра"), Qt::DisplayRole);
        ui->tableView->hideColumn(0);
    }

    else if(nameTable == "semestr")
    {
        table->setHeaderData(0, Qt::Horizontal, QObject::tr("Семестр"), Qt::DisplayRole);
    }

    table->select();
    //ui->tableView->
}

unsigned MainWindow::const_hash(char const *input)
{
    return *input ?
    static_cast<unsigned int>(*input) + 33 * const_hash(input + 1) :
    5381;
}

void MainWindow::Connect()
{
    db = QSqlDatabase::addDatabase("QPSQL");
    db.setHostName(formAutorization->host);
    db.setPort(formAutorization->port);
    db.setDatabaseName("PABD");
    db.setUserName(formAutorization->user);
    db.setPassword(formAutorization->password);
    formAutorization->hide();
    if(!db.open())
        QMessageBox::critical(this, tr("ERROR!"),
        db.lastError().databaseText());
    /*else
    QMessageBox::information(this, tr("SUCCESS!"),
    tr("Соединение установлено! Выберите таблицу для работы"));*/
    model = new QSqlRelationalTableModel(0, db);
    ui->tableView->setModel(model);
}

void MainWindow::Disconnect()
{
    model = new QSqlRelationalTableModel(0, db);
    ui->tableView->setModel(model);
    db.close();
    formAutorization->hide();
}

void MainWindow::on_addButton_clicked()
{
    switch (const_hash(selectedTable.toStdString().c_str())) {

        case 3566738188: //selectTable("course");
            formAdd->Set("Номер курса", "", "", "");
            formAdd->show();
            break;
        case 34458455: //selectTable("discipline");
            formAdd->Set("Наименование дисциплины", "", "", "");
            formAdd->show();
            break;
        case 2821064468: //selectTable("speciality");
            formAdd->Set("Наименование специальности", "", "", "");
            formAdd->show();
            break;
        case 2581877950: //selectTable("gupr_elem");
            formAdd->Set("Наименование ГУПР", "", "", "");
            formAdd->show();
            break;
        case 1202426404:
            //selectTable("kafedra");
            formAdd->Set("Наименование Кафедры", "", "", "");
            formAdd->show();
            break;
        case 4111733963:
            //selectTable("number_weeks");
            formAdd->Set("Количество недель", "", "", "");
            formAdd->show();
            break;
        case 3415898536:
            //selectTable("semestr");
            formAdd->Set("Номер семестра", "", "", "");
            formAdd->show();
            break;
    }
}

void MainWindow::Add()
{
    switch (const_hash(selectedTable.toStdString().c_str())) {

        case 3566738188: //selectTable("course");
            db.exec("select insertintocourse(" + formAdd->arg1 + ")");
            break;
        case 34458455: //selectTable("discipline");
            db.exec("select insertintodiscipline('" + formAdd->arg1 + "')");
            break;
        case 2821064468: //selectTable("speciality");
            db.exec("select insertintospeciality('" + formAdd->arg1 + "')");
            break;
        case 2581877950: //selectTable("gupr_elem");
            db.exec("select insertintogupr_elem('" + formAdd->arg1 + "')");
            break;
        case 1202426404:
            //selectTable("kafedra");
            db.exec("select insertintokafedra('" + formAdd->arg1 + "')");
            break;
        case 4111733963:
            //selectTable("number_weeks");
            db.exec("select insertintonumber_weeks('" + formAdd->arg1 + "')");
            break;
        case 3415898536:
            //selectTable("semestr");
            db.exec("select insertintosemestr('" + formAdd->arg1 + "')");
            break;
    }

    formAdd->hide();
    table->select();
}

void MainWindow::Dismiss()
{
    formAdd->hide();
}


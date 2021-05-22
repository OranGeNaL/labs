QT       += core gui \
    sql \
    widgets

greaterThan(QT_MAJOR_VERSION, 4): QT += widgets

CONFIG += c++11

# You can make your code fail to compile if it uses deprecated APIs.
# In order to do so, uncomment the following line.
#DEFINES += QT_DISABLE_DEPRECATED_BEFORE=0x060000    # disables all the APIs deprecated before Qt 6.0.0

SOURCES += \
    authorization.cpp \
    gruppa.cpp \
    gupr.cpp \
    main.cpp \
    mainwindow.cpp \
    uch_plan.cpp

HEADERS += \
    authorization.h \
    gruppa.h \
    gupr.h \
    mainwindow.h \
    uch_plan.h

FORMS += \
    authorization.ui \
    gruppa.ui \
    gupr.ui \
    mainwindow.ui \
    uch_plan.ui

# Default rules for deployment.
qnx: target.path = /tmp/$${TARGET}/bin
else: unix:!android: target.path = /opt/$${TARGET}/bin
!isEmpty(target.path): INSTALLS += target

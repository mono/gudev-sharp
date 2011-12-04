AC_INIT(gudev-sharp, 0.2)
AM_INIT_AUTOMAKE([foreign])
AM_MAINTAINER_MODE

API_VERSION=3.0.0.0
AC_SUBST(API_VERSION)

dnl Find pkg-config
AC_PATH_PROG(PKG_CONFIG, pkg-config, no)
if test "x$PKG_CONFIG" = "xno"; then
        AC_MSG_ERROR([You need to install pkg-config])
fi

MONO_REQUIRED_VERSION=2.0
UDEV_REQUIRED_VERSION=146

PKG_CHECK_MODULES(BASE_DEPENDENCIES, gudev-1.0 >= $UDEV_REQUIRED_VERSION)
PKG_CHECK_MODULES(MONO_DEPENDENCY, mono >= $MONO_REQUIRED_VERSION, has_mono=true, has_mono=false)

GENERATED_SOURCES=generated/*.cs
AC_PATH_PROG(RUNTIME, mono, no)
AC_PATH_PROG(CSC, gmcs, no)
LIB_PREFIX=.so
LIB_SUFFIX=

AC_SUBST(GENERATED_SOURCES)
AC_SUBST(LIB_PREFIX)
AC_SUBST(LIB_SUFFIX)

AC_SUBST(BASE_DEPENDENCIES_CFLAGS)
AC_SUBST(BASE_DEPENDENCIES_LIBS)

dnl Find GLib#
PKG_CHECK_MODULES(GLIB_SHARP, glib-sharp-3.0 >= 2.99.0)
AC_SUBST(GLIB_SHARP_CFLAGS)
AC_SUBST(GLIB_SHARP_LIBS)

dnl Find GAPI
PKG_CHECK_MODULES(GAPI, gapi-3.0 >= 2.99.0)

AC_PATH_PROG(GACUTIL, gacutil, no)
if test "x$GACUTIL" = "xno" ; then
        AC_MSG_ERROR([No gacutil tool found])
fi

AC_SUBST(GACUTIL)

AC_OUTPUT([
Makefile
gudev/gudev-sharp.dll.config
gudev/Makefile
gudev/AssemblyInfo.cs
gudev-sharp-3.0.pc
])

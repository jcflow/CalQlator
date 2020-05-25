# -*- mode: python ; coding: utf-8 -*-

block_cipher = None


a = Analysis(['main.py'],
             pathex=['/Users/jcflow/Projects/CalQlator'],
             binaries=[],
             datas=[('/usr/local/lib/python3.7/site-packages/Python.Runtime.dll', '.'), ('build/Models.dll', '.'), ('Views/main_window.ui', 'Views'), ('Controllers/dictionary.json', 'Controllers')],
             hiddenimports=['clr'],
             hookspath=[],
             runtime_hooks=[],
             excludes=[],
             win_no_prefer_redirects=False,
             win_private_assemblies=False,
             cipher=block_cipher,
             noarchive=False)
pyz = PYZ(a.pure, a.zipped_data,
             cipher=block_cipher)
exe = EXE(pyz,
          a.scripts,
          a.binaries,
          a.zipfiles,
          a.datas,
          [],
          name='CalQlator',
          debug=False,
          bootloader_ignore_signals=False,
          strip=False,
          upx=True,
          upx_exclude=[],
          runtime_tmpdir=None,
          console=False , icon='docs/icon.icns')
app = BUNDLE(exe,
             name='CalQlator.app',
             icon='icon.icns',
             bundle_identifier=None)
